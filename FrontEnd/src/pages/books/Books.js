import React, { useState, useEffect } from "react";
import { Table, Input, message } from "antd";
import axios from "axios";

const { Search } = Input;

const BooksTable = () => {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(false);
  const [pagination, setPagination] = useState({ current: 1, pageSize: 10 });
  const [searchTerm, setSearchTerm] = useState("");
  const [sortColumn, setSortColumn] = useState("");
  const [sortOrder, setSortOrder] = useState("");

  const fetchData = async (params = {}) => {
    setLoading(true);
    try {
      const response = await axios.post(
        "https://localhost:7244/api/book/filter",
        {
          SearchTerm: "",
          SortColumn: "",
          SortOrder: "",
          Page: 1,
          PageSize: 10,
        }
      );
      setData(response.data.items);
      setPagination({
        ...params.pagination,
        total: response.data.totalCount,
      });
    } catch (error) {
      message.error("Failed to fetch data: " + error.message);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchData({
      searchTerm,
      sortColumn,
      sortOrder,
      pagination,
    });
  }, [searchTerm, sortColumn, sortOrder, pagination]);

  const handleTableChange = (pagination, filters, sorter) => {
    fetchData({
      pagination,
      searchTerm,
      sortColumn: sorter.field,
      sortOrder: sorter.order,
    });
  };

  const handleSearch = (value) => {
    setSearchTerm(value);
    setPagination({ ...pagination, current: 1 });
  };

  const columns = [
    {
      title: "Title",
      dataIndex: "title",
      sorter: true,
    },
    {
      title: "Author",
      dataIndex: "author",
      sorter: true,
    },
  ];

  return (
    <>
      <Search
        placeholder="Search books"
        onSearch={handleSearch}
        style={{ marginBottom: 16, width: 200 }}
      />
      <Table
        columns={columns}
        rowKey={(record) => record.id}
        dataSource={data}
        pagination={pagination}
        loading={loading}
        onChange={handleTableChange}
      />
    </>
  );
};

export default BooksTable;
