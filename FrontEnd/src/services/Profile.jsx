import axiosConfig from "../configs/axiosConfig";

export const apiGetProfile = (id) =>
  new Promise(async (resolve, reject) => {
    try {
      const response = await axiosConfig({
        method: "get",
        url: `https://localhost:7244/api/users/${id}`,
      });
      resolve(response);
    } catch (error) {
      reject(error);
    }
  });
