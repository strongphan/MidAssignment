import axiosConfig from "../configs/axiosConfig";

export const apiLogin = (params) =>
  new Promise(async (resolve, reject) => {
    try {
      const response = await axiosConfig({
        method: "post",
        url: `https://localhost:7244/api/users/login`,
        data: params,
      });
      resolve(response);
    } catch (error) {
      reject(error);
    }
  });
export const apiRegister = (params) =>
  new Promise(async (resolve, reject) => {
    try {
      const response = await axiosConfig({
        method: "post",
        url: `https://localhost:7244/api/users/register`,
        data: params,
      });
      resolve(response);
    } catch (error) {
      reject(error);
    }
  });
