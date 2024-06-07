import axiosConfig from "../configs/axiosConfig";
const baseUrl = "https://localhost:7244/api/categories/";
export const apiGetCategory = (id) =>
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

export const apiCreateCategory = (category) =>
  new Promise(async (resolve, reject) => {
    try {
      const response = await axiosConfig({
        method: "post",
        url: `${baseUrl}`,
        data: category,
      });
      resolve(response);
    } catch (error) {
      reject(error);
    }
  });

export const apiDeleteCategory = (id) =>
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

export const apiUpdateCategory = (category) =>
  new Promise(async (resolve, reject) => {
    try {
      const response = await axiosConfig({
        method: "put",
        url: `${baseUrl}${category.id}`,
        data: category,
      });
      resolve(response);
    } catch (error) {
      reject(error);
    }
  });
