import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { apiGetPosts } from "../../services/Posts";

const DetailPost = () => {
  const [post, setPost] = useState({});
  const [error, setError] = useState(null);
  const { id } = useParams();
  const navigate = useNavigate();

  const fetchPost = async (id) => {
    setPost(undefined);
    setError(null);
    try {
      const response = await apiGetPosts(id);
      setPost(response.data);
    } catch (error) {
      setError("Failed to fetch Posts data");
    } finally {
      console.log(post);
    }
  };

  useEffect(() => {
    fetchPost(id);
  }, [id]);
  return (
    <div>
      {error ? (
        <div>{error}</div>
      ) : (
        <div className="gap-4 py-10 justify-start items-start">
          <h1 className="text-4xl font-bold">Post No {id}</h1>
          <h1 className="text-3xl font-bold">User Id: {post?.userId}</h1>
          <h1 className="text-3xl font-bold">Title: {post?.title}</h1>
          <h1 className="text-3xl font-bold">Body:</h1>
          <h1 className="text-3xl px-5 py-5">{post?.body}</h1>
        </div>
      )}
      <button
        className="bg-green-200 rounded-md mt-10 px-3 py-3"
        onClick={() => navigate("/posts")}
      >
        Back to Posts
      </button>
    </div>
  );
};

export default DetailPost;
