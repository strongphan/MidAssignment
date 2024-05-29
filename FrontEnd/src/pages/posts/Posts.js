import { Input, Modal, Space, Table } from "antd";
import { useEffect, useState } from "react";
import { Button } from "antd/es/radio/index";
import {
  DeleteOutlined,
  EditOutlined,
  ExpandAltOutlined,
} from "@ant-design/icons";
import { useNavigate } from "react-router-dom";
import { apiGetPosts, apiDeletePosts } from "../../services/Posts";

function PostsPage() {
  return (
    <div>
      <Space>
        <GetAllPosts />
      </Space>
    </div>
  );
}

function GetAllPosts() {
  const [dataSource, setDataSource] = useState([]);
  const [isLoading, setLoading] = useState(false);
  const navigator = useNavigate();
  const fetchPosts = async () => {
    try {
      setLoading(true);
      const response = await apiGetPosts("");
      setDataSource(response.data);
    } catch (error) {
      console.error("Error fetching data:", error);
    } finally {
      setLoading(false);
    }
  };
  useEffect(() => {
    fetchPosts();
  }, []);

  return (
    <div>
      <PostTable posts={dataSource} isLoading={isLoading} />
    </div>
  );
  function PostTable({ posts, isLoading }) {
    const [searchTerm, setSearchTerm] = useState("");

    const handleSearch = (value) => {
      setSearchTerm(value);
    };

    const filteredPosts = posts.filter(
      (post) =>
        post.title.toLowerCase().includes(searchTerm.toLowerCase()) ||
        post.body.toLowerCase().includes(searchTerm.toLowerCase())
    );

    function handleDelete(id) {
      console.log("Delete", id);
      Modal.confirm({
        title: "Confirm Delete",
        content: "Are you sure you want to delete this post?",
        onOk() {
          Delete(id);
        },
      });
    }
    async function Delete(Id) {
      try {
        await apiDeletePosts(Id);
        return;
      } catch (error) {
        console.error("Error fetching data:", error);
        throw error;
      } finally {
        fetchPosts();
      }
    }

    const columns = [
      {
        title: "User ID",
        dataIndex: "userId",
        key: "userId",
        sorter: (a, b) => a.userId - b.userId,
      },
      {
        title: "Title",
        dataIndex: "title",
        key: "title",
        sorter: (a, b) => a.title.localeCompare(b.title),
      },
      {
        title: "Body",
        dataIndex: "body",
        key: "body",
        sorter: (a, b) => a.title.localeCompare(b.title),
      },
      {
        title: "Actions",
        key: "actions",
        render: (text, record) => (
          <Space>
            <Button type="primary" onClick={() => navigator(`${record.id}`)}>
              <ExpandAltOutlined />
            </Button>
            <Button
              type="primary"
              onClick={() => navigator(`edit/${record.id}`)}
            >
              <EditOutlined />
            </Button>
            <Button type="danger" onClick={() => handleDelete(record.id)}>
              <DeleteOutlined />
            </Button>
          </Space>
        ),
      },
    ];

    return (
      <div>
        <div
          style={{
            display: "flex",
            justifyContent: "space-between",
            padding: "10px 0",
          }}
        >
          <Input.Search
            placeholder="Search by title or body"
            onSearch={handleSearch}
            style={{ width: 400 }}
          />
          <Button type="primary" onClick={() => navigator("create")}>
            Create
          </Button>
        </div>
        <Table
          dataSource={filteredPosts}
          columns={columns}
          loading={isLoading}
        />
      </div>
    );
  }
}
export default PostsPage;
