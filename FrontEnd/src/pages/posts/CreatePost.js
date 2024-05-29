import { Form, Input, Button } from "antd";
import { useNavigate } from "react-router-dom";
import { apiCreatePosts } from "../../services/Posts";

const post = {
  userId: "",
  id: "",
  title: "",
  body: "",
};

async function CreatePost(post) {
  try {
    await apiCreatePosts(post);
    return;
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  } finally {
  }
}

const CreatePostForm = () => {
  const navigator = useNavigate();

  const onFinish = (values) => {
    const { userId, id, title, body } = values;
    const updatedPost = { ...post, userId, id, title, body };
    CreatePost(updatedPost);
    navigator("/posts");
  };

  return (
    <Form name="createPostForm" onFinish={onFinish}>
      <Form.Item
        label="Id"
        name="id"
        rules={[{ required: true, message: "Please input the Id!" }]}
      >
        <Input />
      </Form.Item>
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
          Create Post
        </Button>
      </Form.Item>
    </Form>
  );
};

export default CreatePostForm;
