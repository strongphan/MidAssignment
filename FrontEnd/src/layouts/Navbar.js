import { FileOutlined, HomeOutlined, ProfileOutlined } from "@ant-design/icons";
import { Menu } from "antd";
import { useNavigate } from "react-router-dom";

function NavBar() {
  const nav = useNavigate();

  const handleMenuClick = (key) => {
    nav(key);
  };

  return (
    <div className="Navbar">
      <Menu mode="vertical" onClick={({ key }) => handleMenuClick(key)}>
        <Menu.Item key="/">
          <HomeOutlined />
          Home
        </Menu.Item>
        <Menu.Item key="/posts">
          <FileOutlined />
          Posts
        </Menu.Item>
        <Menu.Item key="/books">
          <FileOutlined />
          Books
        </Menu.Item>
        <Menu.Item key="/profile">
          <ProfileOutlined />
          Profiles
        </Menu.Item>
        <Menu.Item key="/login">Login/Logout</Menu.Item>
      </Menu>
    </div>
  );
}

export default NavBar;
