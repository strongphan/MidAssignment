import axiosConfig from "../configs/axiosConfig";
const baseUrl = "https://localhost:7244/api/borrowing_requests/";

export const apiCreateRequest = (booksId) =>
  new Promise(async (resolve, reject) => {
    try {
      const response = await axiosConfig({
        method: "post",
        url: `${baseUrl}`,
        data: booksId,
      });
      resolve(response);
    } catch (error) {
      reject(error);
    }
  });
export const apiGetFilterRequest = (params) =>
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
export const apiGetFilterBooks = (params) =>
  new Promise(async (resolve, reject) => {
    try {
      const response = await axiosConfig({
        method: "post",
        url: `${baseUrl}/not_returned/filter`,
        data: params,
      });
      resolve(response);
    } catch (error) {
      reject(error);
    }
  });
export const apiGetUserRequest = (id, params) =>
  new Promise(async (resolve, reject) => {
    try {
      const response = await axiosConfig({
        method: "post",
        url: `${baseUrl}user/${id}`,
        data: params,
      });
      resolve(response);
    } catch (error) {
      reject(error);
    }
  });
export const apiUpdateStatusRequest = (requestID, status) =>
  new Promise(async (resolve, reject) => {
    try {
      const response = await axiosConfig({
        method: "put",
        url: `${baseUrl}status/${requestID}?status=${status}`,
      });
      resolve(response);
    } catch (error) {
      reject(error);
    }
  });
export const apiUpdateReturnRequest = (requestID) =>
  new Promise(async (resolve, reject) => {
    try {
      const response = await axiosConfig({
        method: "put",
        url: `${baseUrl}return/${requestID}`,
      });
      resolve(response);
    } catch (error) {
      reject(error);
    }
  });
