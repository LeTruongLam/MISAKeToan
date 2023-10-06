const MISAApi = {
  deleteData(CustomerId) {
    return new Promise((resolve, reject) => {
      this.$axios
        .delete(`https://cukcuk.manhnv.net/api/v1/customers/${CustomerId}`)
        .then((res) => {
          console.log("OK: ", res);
          resolve(res); // Trả về kết quả khi xóa thành công
        })
        .catch((error) => {
          console.log("Lỗi khi xóa khách hàng:", error);
          reject(error); // Trả về lỗi khi xóa không thành công
        });
    });
  },

//   getData() {
//     this.$axios
//       .get("https://cukcuk.manhnv.net/api/v1/customers")
//       .then((response) => {
//         response.data;
//         console.log("Lấy dữ liệu thành công");
//       })
//       .catch((error) => {
//         console.log("Lỗi khi lấy dữ liệu:", error);
//         throw error;
//       });
//   },

  addData(data) {
    return new Promise((resolve, reject) => {
      this.$axios
        .post("https://cukcuk.manhnv.net/api/v1/customers", data)
        .then((res) => {
          console.log("Thêm dữ liệu thành công");
          const newCustomer = res.data;
          resolve(newCustomer); // Trả về khách hàng mới được thêm khi thành công
        })
        .catch((error) => {
          console.log("Lỗi khi thêm dữ liệu:", error);
          reject(error); // Trả về lỗi khi thêm dữ liệu không thành công
        });
    });
  },
};

export default MISAApi;
