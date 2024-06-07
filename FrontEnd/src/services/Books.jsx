import axiosConfig from "../configs/axiosConfig";
const baseUrl = `https://localhost:7244/api/books/`;

export const apiGetFilterBooks = (params) =>
  new Promise(async (resolve, reject) => {
    try {
      const response = await axiosConfig({
        method: "post",
        url: `${baseUrl}filter`,
        data: params,
      });
      resolve(response);
    } catch (error) {
      reject(error);
    }
  });
export const apiGetBooks = (id) =>
  new Promise(async (resolve, reject) => {
    try {
      const response = await axiosConfig({
        method: "get",
        url: `${baseUrl}${id}`,
      });
      resolve(response);
    } catch (error) {
      reject(error);
    }
  });

export const apiCreateBooks = (book) =>
  new Promise(async (resolve, reject) => {
    try {
      const response = await axiosConfig({
        method: "post",
        url: `${baseUrl}`,
        data: book,
      });
      resolve(response);
    } catch (error) {
      reject(error);
    }
  });

export const apiDeleteBooks = (id) =>
  new Promise(async (resolve, reject) => {
    try {
      const response = await axiosConfig({
        method: "delete",
        url: `${baseUrl}${id}`,
      });
      resolve(response);
    } catch (error) {
      reject(error);
    }
  });

export const apiUpdateBooks = (book) =>
  new Promise(async (resolve, reject) => {
    try {
      const response = await axiosConfig({
        method: "put",
        url: `${baseUrl}${book.id}`,
        data: book,
      });
      resolve(response);
    } catch (error) {
      reject(error);
    }
  });
