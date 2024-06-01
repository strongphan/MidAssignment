import { useRoutes } from "react-router-dom";
import React, { Suspense } from "react";
import { NotFound } from "../pages";
import { RequiredAuth } from "../components";
import { path } from "./routeContants";

const LoginLazy = React.lazy(() => import("../pages/Login"));
const EditPostLazy = React.lazy(() => import("../pages/posts/EditPost"));
const CreatePostLazy = React.lazy(() => import("../pages/posts/CreatePost"));
const DetailPostLazy = React.lazy(() => import("../pages/posts/DetailPost"));
const PostsLazy = React.lazy(() => import("../pages/posts/Posts"));
const ProfileLazy = React.lazy(() => import("../pages/Profile"));
const HomeLazy = React.lazy(() => import("../pages/home/Home"));
const BooksTableLazy = React.lazy(() => import("../pages/books/Books"));

export const AppRoute = () => {
  const elements = useRoutes([
    {
      path: path.HOME,
      element: (
        <Suspense>
          <HomeLazy />
        </Suspense>
      ),
      errorElement: <NotFound />,
    },
    {
      path: path.POSTS,
      element: (
        <Suspense>
          <PostsLazy />
        </Suspense>
      ),
      errorElement: <NotFound />,
    },
    {
      path: path.POSTS,
      element: (
        <Suspense>
          <PostsLazy />
        </Suspense>
      ),
      errorElement: <NotFound />,
    },
    {
      path: path.BOOKS,
      element: (
        <Suspense>
          <BooksTableLazy />
        </Suspense>
      ),
      errorElement: <NotFound />,
    },
    {
      path: path.DETAILPOST__ID,
      element: (
        <Suspense>
          <DetailPostLazy />
        </Suspense>
      ),
      errorElement: <NotFound />,
    },
    {
      path: path.EDITPOST__ID,
      element: (
        <Suspense>
          <EditPostLazy />
        </Suspense>
      ),
      errorElement: <NotFound />,
    },
    {
      path: path.CREATEPOST,
      element: (
        <Suspense>
          <CreatePostLazy />
        </Suspense>
      ),
      errorElement: <NotFound />,
    },
    {
      path: path.LOGIN,
      element: (
        <Suspense>
          <LoginLazy />
        </Suspense>
      ),
      errorElement: <NotFound />,
    },
    {
      path: path.PROFILE,
      element: (
        <RequiredAuth>
          <Suspense>
            <ProfileLazy />
          </Suspense>
        </RequiredAuth>
      ),
    },
  ]);

  return elements;
};
