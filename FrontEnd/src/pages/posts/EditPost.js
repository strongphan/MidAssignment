import { Form, Input, Button } from "antd";
import { useNavigate, useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { apiGetPosts, apiUpdatePosts } from "../../services/Posts";

const EditPost = () => {
  const navigator = useNavigate();
  const { id } = useParams();
  const [form] = Form.useForm();
  const [post, setPost] = useState({
    userId: "",
    id: "",
    title: "",
    body: "",
  });
  const fetchPost = async () => {
    try {
      const response = await apiGetPosts(id);
      const data = response.data;
      setPost(data);
      form.setFieldsValue(data);
    } catch (error) {
      console.error("Error fetching post:", error);
    }
  };
  useEffect(() => {
    fetchPost();
  }, [id]);

  async function EditPost(post) {
    try {
      post.id = id;
      await apiUpdatePosts(post);
      return;
    } catch (error) {
      console.error("Error fetching data:", error);
      throw error;
    } finally {
    }
  }
  const onFinish = (values) => {
    console.log(values);
    EditPost(values);
    navigator("/posts");
  };

  return (
    <div>
      {post ? (
        <Form
          form={form}
          name="EditPostForm"
          initialValues={post}
          onFinish={onFinish}
        >
          <Form.Item
            label="User Id"
            name="userId"
            rules={[{ required: true, message: "Please input the User Id!" }]}
          >
            <Input />
          </Form.Item>
          <Form.Item
            label="Title"
            name="title"
            rules={[{ required: true, message: "Please input the title!" }]}
          >
            <Input />
          </Form.Item>
          <Form.Item
            label="Body"
            name="body"
            rules={[{ required: true, message: "Please input the body!" }]}
          >
            <Input.TextArea />
          </Form.Item>
          <Form.Item>
            <Button type="primary" htmlType="submit">
              Update Post
            </Button>
          </Form.Item>
        </Form>
      ) : (
        "Loading..."
      )}
    </div>
  );
};

export default EditPost;
