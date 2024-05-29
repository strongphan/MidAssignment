import React from "react";
import { Button, Checkbox, Form, Input } from "antd";
import { message } from "antd";
import { apiGetToken } from "../services/Profile";
import { useAuthContext } from "../context/authContext";
import { Navigate, useNavigate } from "react-router-dom";
import { path } from "../route/routeContants";

const LoginPage = () => {
  const { setIsAuthenticated } = useAuthContext();
  const navigator = useNavigate();
  const onFinish = async (values) => {
    try {
      const response = await apiGetToken();
      localStorage.setItem("token", response?.data?.token);
      localStorage.setItem("userId", response?.data?.userId);
      setIsAuthenticated(true);
      navigator("/posts");
    } catch (error) {
      console.error("Error logging:", error);
    }
  };
  const onFinishFailed = (errorInfo) => {
    console.log("Failed:", errorInfo);
    message.error("Form submission failed. Please check your inputs.");
  };
  return (
    <Form
      name="basic"
      labelCol={{
        span: 8,
      }}
      wrapperCol={{
        span: 16,
      }}
      style={{
        maxWidth: 600,
      }}
      initialValues={{
        remember: true,
      }}
      onFinish={onFinish}
      onFinishFailed={onFinishFailed}
      autoComplete="off"
    >
      <Form.Item
        label="Email"
        name="email"
        rules={[
          {
            type: "email",
            message: "The input is not valid E-mail!",
          },
          {
            required: true,
            message: "Please input your email!",
          },
        ]}
      >
        <Input />
      </Form.Item>

      <Form.Item
        label="Password"
        name="password"
        rules={[
          {
            required: true,
            message: "Please input your password!",
          },
          {
            pattern:
              /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/,
            message:
              "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one symbol.",
          },
        ]}
      >
        <Input.Password />
      </Form.Item>

      <Form.Item
        name="remember"
        valuePropName="checked"
        wrapperCol={{
          offset: 8,
          span: 16,
        }}
      >
        <Checkbox>Remember me</Checkbox>
      </Form.Item>

      <Form.Item
        wrapperCol={{
          offset: 8,
          span: 16,
        }}
      >
        <Button type="primary" htmlType="submit">
          Submit
        </Button>
      </Form.Item>
    </Form>
  );
};
export default LoginPage;
