<template>
  <div class="header-wrapper">
    <h1 class="title-main">Nhân viên</h1>
    <a href="#">
      <m-button
        content="Thêm mới nhân viên"
        @click="onShowEmployeeDetail"
      ></m-button>
    </a>
  </div>
  <div class="container-content">
    <div class="header-container-content">
      <div class="first-left-content">
        Đã chọn: <span class="text-boil">{{ selectedCount }}</span>

        <a
          href="#"
          v-if="showSelected"
          class="m-left-16 m-red-color m-a-style"
          @click="deleteAll"
          >Bỏ chọn</a
        >
        <a
          href="#"
          v-if="showSelected"
          class="m-left-16 m-blue-color m-a-style"
          @click="selectAll"
          >Chọn tất cả
        </a>
        <a
          href="#"
          class="delete-row"
          v-if="showSelected"
          @click="deleteSelected"
        >
          <p class="icon-delete"></p>
          <p class="">Xóa</p>
        </a>
      </div>
      <div class="right-left-content">
        <input
          id="txtId"
          type="text"
          placeholder="Tìm theo mã, tên nhân viên"
          v-model="searchQuery"
        />

        <!-- <m-search content="Tìm theo mã, tên nhân viên"></m-search> -->
        <i class="excel-icon" @click="searchEmployee"> </i>
        <i class="reload-icon" @click="handleLoading"> </i>
      </div>
    </div>
    <div class="table-content">
      <table class="employee-table">
        <thead>
          <tr>
            <th class="employee-table__header text-center size-checkbox">
              <input
                type="checkbox"
                id="myCheckbox"
                v-model="allSelected"
                @change="selectAlltableDatas"
              />
            </th>
            <th class="employee-table__header">Mã nhân viên</th>
            <th class="employee-table__header">Tên nhân viên</th>
            <th class="employee-table__header">Giới tính</th>
            <th class="employee-table__header text-center">Ngày sinh</th>
            <th class="employee-table__header">
              <label title="Số chứng minh nhân dân">Số CMND</label>
            </th>
            <th class="employee-table__header">Chức danh</th>
            <th class="employee-table__header">Tên đơn vị</th>
            <th class="employee-table__header text-center">Chức năng</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="employee in pagedEmployees" :key="employee.EmployeeId">
            <td class="employee-table__data text-center size-checkbox">
              <input
                type="checkbox"
                id="myCheckbox"
                :value="employee.EmployeeId"
                v-model="selectedtableDatas"
                @change="updateSelectedCount"
              />
            </td>
            <td class="employee-table__data">{{ employee.EmployeeCode }}</td>
            <td class="employee-table__data">{{ employee.FullName }}</td>
            <td class="employee-table__data">
              {{ getGenderName(employee.Gender) }}
            </td>
            <td class="employee-table__data text-center">
              {{ formatDate(employee.DateOfBirth) }}
            </td>
            <td class="employee-table__data">{{ employee.PhoneNumber }}</td>
            <td class="employee-table__data">{{ employee.CompanyNames }}</td>
            <td class="employee-table__data">{{ employee.CompanyName }}</td>
            <td class="employee-table__data text-center">
              <div class="edit">
                <a href="#">Sửa</a>
                <a
                  href="#"
                  class="down-icon"
                  @click="toggleCombobox(employee.EmployeeId)"
                >
                  <m-contextmenu
                    v-if="employee.showCombobox"
                    :menuItems="customItems2"
                    @onItemClick="
                      onContextMenuItemClick(employee.EmployeeId, $event)
                    "
                    @onClose="onCloseContextmenu"
                  ></m-contextmenu>
                </a>
              </div>
            </td>
          </tr>
          <!-- <div v-if="employeeNotFornd">Khong tim thay nhan vie</div> -->
        </tbody>
      </table>
    </div>
    <div class="table-end">
      <div class="table-end-left">
        Tổng số <strong>{{ this.employees.length }}</strong> bản ghi
      </div>
      <div class="table-end-right">
        <div>Bản ghi / Trang</div>
        <div class="search-bar">
          <input type="text" placeholder="" :value="customItems[0]" />
          <label
            for="search-box"
            class="down-icon-black"
            @click="onShowCombobox"
          ></label>
          <m-combobox
            v-if="showCombobox"
            :items="customItems"
            @onClose="onCloseCombobox"
          ></m-combobox>
        </div>

        <div class="page-container">
          <a class="right-icon-black" @click="previousPage"></a>
          <a class="left-icon-black" @click="nextPage"></a>
        </div>
      </div>
    </div>
  </div>
  <m-loading v-if="showLoading"></m-loading>
  <EmployeeDetail
    v-if="showEmployeeDetail"
    @saveSuccess="handleSaveSuccess"
  ></EmployeeDetail>
  <m-notify
    v-if="showNotify"
    :title="titleNotify"
    :type="iconNotify"
    :message="contentNotify"
  ></m-notify>
</template>
<script>
import EmployeeDetail from "./EmployeeDetail.vue";
export default {
  name: "TheEmployeeList",
  props: [""],
  components: {
    EmployeeDetail,
  },
  created() {
    // Đăng ký sự kiện "onClose" và gán hàm xử lý onCloseEmployeeDetail
    this.$emitter.on("onClose", this.onCloseEmployeeDetail);
    // Lấy dữ liệu từ API

    this.fetchEmployees();
  },
  computed: {
    // Trả về số checkbox đã được chọn
    selectedCount() {
      return this.selectedtableDatas.length;
    },
    // Tính tổng số trang
    totalPages() {
      return Math.ceil(this.employees.length / this.pageSize); // Tính tổng số trang
    },
    pagedEmployees() {
      const startIndex = (this.currentPage - 1) * this.pageSize; // Vị trí bắt đầu của bản ghi trên trang hiện tại
      const endIndex = startIndex + this.pageSize; // Vị trí kết thúc của bản ghi trên trang hiện tại
      return this.employees.slice(startIndex, endIndex); // Lấy danh sách bản ghi trên trang hiện tại
    },
  },

  methods: {
    searchEmployee() {
      const query = encodeURIComponent(this.searchQuery); // Mã hóa truy vấn để đảm bảo đúng định dạng URL

      const url = `https://localhost:7102/api/v1/Employees/search?query=${query}`;

      this.$axios
        .get(url)
        .then((response) => {
          const foundEmployee = response.data;
          if (foundEmployee) {
            this.employees = foundEmployee;
            this.currentPage = 1;
            console.log("Nhân viên được tìm thấy:", foundEmployee);

            // Thực hiện các hành động với nhân viên tìm thấy
            this.searchQuery = "";
            document.getElementById("txtId").focus();
          } else {
            console.log(
              "Không tìm thấy nhân viên với mã id:",
              this.searchQuery
            );
          }
        })
        .catch((error) => {
          this.employeeNotFornd = true;

          console.error("Lỗi khi tìm kiếm nhân viên:", error);
        });
    },
    // Lấy dữ liệu từ API
    fetchEmployees() {
      this.$axios
        .get("https://localhost:7102/api/v1/Employees")
        .then((response) => {
          document.getElementById("txtId").focus();

          this.employees = response.data; // Lưu danh sách bản ghi từ backend vào biến employees
        })
        .catch((error) => {
          console.error("Lỗi khi lấy danh sách bản ghi:", error);
        });
    },
    previousPage() {
      if (this.currentPage > 1) {
        this.currentPage--;
      }
    },
    nextPage() {
      if (this.currentPage < this.totalPages) {
        this.currentPage++;
      }
    },

    // Xử lý hiển thị và ẩn loading khi lấy dữ liệu
    handleLoading() {
      this.showLoading = true; // Hiển thị loading
      this.currentPage = 1; // Đặt lại trang hiện tại về 1
      setTimeout(() => {
        this.showLoading = false; // Ẩn loading sau 1 giây
      }, 1000);
      this.fetchEmployees(); // Gọi phương thức fetchEmployees để lấy dữ liệu
    },

    // Đóng form và thông báo Cất thành công
    handleSaveSuccess() {
      this.fetchEmployees();
      // Thực hiện đóng form
      this.onCloseEmployeeDetail(); // Gọi phương thức để đóng form
      // Hiển thị thông báo thành công
      this.contentNotify = this.$MISAResource["VN"].FormEdited; // Nội dung thông báo thành công
      this.titleNotify = this.$MISAEnum["MISANotify"].Success.title; // Tiêu đề thông báo thành công
      this.iconNotify = this.$MISAEnum.MISANotify.Success.id; // ID của biểu tượng thông báo thành công
      this.showNotify = true; // Hiển thị thông báo
      setTimeout(() => {
        this.showNotify = false; // Tự động ẩn thông báo sau 3 giây
      }, 3000);
    },
    //
    /**
     * Xử lý sự kiện khi một mục menu ngữ cảnh được nhấp vào.
     * @param {number} EmployeeId - ID của khách hàng.
     * @param {number} index - Chỉ số của mục menu được nhấp vào.
     *  Created by Lê Trường Lam ngày 5/9
     */
    onContextMenuItemClick(EmployeeId, index) {
      const selectedMenuItem = this.customItems2[index];
      if (selectedMenuItem === "Xóa") {
        this.pickId(EmployeeId);
      } else {
        console.log(selectedMenuItem);
      }
    },
    /**
     * Chọn nhân viên cần xóa dựa trên mã ID.
     * @param {string} EmployeeId - Mã ID của khách hàng.
     *  Created by Lê Trường Lam ngày 5/9
     */
    pickId(EmployeeId) {
      const employee = this.employees.find(
        (employee) => employee.EmployeeId === EmployeeId
      );
      if (employee) {
        console.log(EmployeeId);
        this.deleteData(EmployeeId);
        this.contentNotify = "Đã xóa thành công"; // Nội dung thông báo xóa thành công
        this.titleNotify = this.$MISAEnum["MISANotify"].Success.title; // Tiêu đề thông báo thành công
        this.iconNotify = this.$MISAEnum["MISANotify"].Success.id; // ID của biểu tượng thông báo thành công
        this.showNotify = true; // Hiển thị thông báo
        setTimeout(() => {
          this.showNotify = false;
        }, 3000);
      } else {
        console.log("Không tìm thấy khách hàng với ID:", EmployeeId);
      }
    },
    /**
     * Xóa dữ liệu từ Id đã chọn
     * @param {string} EmployeeId - Mã ID của khách hàng.
     *  Created by Lê Trường Lam ngày 5/9
     */
    deleteData(EmployeeId) {
      this.$axios
        .delete(`https://localhost:7102/api/v1/Employees/${EmployeeId}`)
        .then((res) => {
          console.log("OK: ", res);
          this.fetchEmployees(); // Thực hiện gọi fetchData để lấy dữ liệu
        })
        .catch((error) => {
          console.log("Lỗi khi xóa khách hàng:", error);
        });
    },
    // Mở form nhân viên
    onShowEmployeeDetail() {
      this.showEmployeeDetail = true;
    },
    // Đóng thông tin nhân viên

    onCloseEmployeeDetail() {
      this.showEmployeeDetail = false;
    },
    /**
     * Chuyển đổi trạng thái hiển thị của combobox cho một mục tableData cụ thể.
     * @param {number} EmployeeId - Id của mục tableData.
     *  Created by Lê Trường Lam ngày 5/9
     */
    toggleCombobox(EmployeeId) {
      // Lặp qua từng phần tử trong mảng employee
      this.employees.forEach((employee) => {
        // Nếu Id của employee trùng với EmployeeId đầu vào
        if (employee.EmployeeId === EmployeeId) {
          // Đảo ngược trạng thái showCombobox của employee
          employee.showCombobox = !employee.showCombobox;
        } else {
          // Nếu không, đặt trạng thái showCombobox của employee thành false
          employee.showCombobox = false;
        }
      });
    },
    /**
     * Chuyển đổi đối tượng date thành chuỗi định dạng ngày/tháng/năm.
     * @param {Date} date - Đối tượng date cần chuyển đổi. Có thể là đối tượng Date
     * @throws {Error} - Nếu không thể chuyển đổi đối tượng date thành đối tượng Date hoặc xảy ra lỗi trong quá trình chuyển đổi.
     *  Created by Lê Trường Lam ngày 5/9
     *
     */
    formatDate(date) {
      try {
        // Chuyển đổi đối tượng date thành một đối tượng Date
        date = new Date(date);
        // Lấy giá trị ngày
        let dateValue = date.getDate();
        // Lấy giá trị tháng (cộng thêm 1 vì tháng trong JavaScript bắt đầu từ 0)
        let monthValue = date.getMonth() + 1;
        // Lấy giá trị năm
        let year = date.getFullYear();
        // Trả về chuỗi định dạng ngày/tháng/năm
        return `${dateValue}/${monthValue}/${year}`;
      } catch (error) {
        // Xử lý lỗi nếu có
        console.error(error);
        // Trả về chuỗi rỗng nếu xảy ra lỗi
        return "";
      }
    },
    // Hiện Combobox
    onShowCombobox() {
      this.showCombobox = true;
    },
    // Đóng Combobox
    onCloseCombobox() {
      this.showCombobox = false;
    },
    // Hiện Contextmenu

    onShowContextmenu() {
      this.showContextMenu = true;
    },
    // Đóng Contextmenu

    onCloseContextmenu() {
      this.showContextMenu = false;
    },
    /**
     * Chọn tất cả checkbox trong bảng.
     * Created by Lê Trường Lam ngày 5/9
     */
    selectAlltableDatas() {
      if (this.allSelected) {
        this.selectedtableDatas = this.employees.map(
          (employee) => employee.EmployeeId
        );
      } else {
        this.selectedtableDatas = [];
      }
    },
    /**
     * Xóa những data đã được chọn
     * Created by Lê Trường Lam ngày 7/9
     */

    deleteSelected() {
      for (let i = 0; i < this.selectedtableDatas.length; i++) {
        this.$axios
          .delete(
            `https://localhost:7102/api/v1/Employees/${this.selectedtableDatas[i]}`
          )
          .then((res) => {
            console.log("OK: ", res);
            this.fetchEmployees(); // Thực hiện gọi fetchData để lấy dữ liệu
            this.contentNotify = "Đã xóa thành công"; // Nội dung thông báo xóa thành công
            this.titleNotify = this.$MISAEnum["MISANotify"].Success.title; // Tiêu đề thông báo thành công
            this.iconNotify = this.$MISAEnum["MISANotify"].Success.id; // ID của biểu tượng thông báo thành công
            this.showNotify = true; // Hiển thị thông báo
            setTimeout(() => {
              this.showNotify = false;
            }, 3000);
          })
          .catch((error) => {
            console.log("Lỗi khi xóa khách hàng:", error);
          });
      }
      this.selectedtableDatas = [];
      this.showSelected = false;
    },

    /**
     * Cập nhật số checkbox trong bảng.
     * Created by Lê Trường Lam ngày 5/9
     */
    updateSelectedCount() {
      if (
        this.allSelected &&
        this.selectedtableDatas.length !== this.employees.length
      ) {
        this.allSelected = false;
      }
      if (this.selectedtableDatas.length > 0) {
        this.showSelected = true;
      } else {
        this.showSelected = false;
      }
    },
    getGenderName(gender) {
      if (gender === this.$MISAEnum.Gender.Female) {
        return "Nữ";
      } else if (gender === this.$MISAEnum.Gender.Male) {
        return "Nam";
      } else if (gender === this.$MISAEnum.Gender.Other) {
        return "Khác";
      } else {
        return "Không xác định";
      }
    },

    // Xóa tất cả
    deleteAll() {
      // Đặt lại selectedtableDatas về mảng rỗng
      this.selectedtableDatas = [];
      this.allSelected = false;
    },
    // Chọn tất cả
    selectAll() {
      this.allSelected = true;
      // Đặt giá trị selectedtableDatas thành danh sách các id của tất cả các mục trong tableDatas
      this.selectedtableDatas = this.employees.map(
        (employee) => employee.EmployeeId
      );
    },
  },
  data() {
    return {
      employeeNotFornd: false,
      searchQuery: "",
      showLoading: false,
      showNotify: false,
      showCombobox: false,
      showDialog: false,
      showContextMenu: false,
      showSelected: false,
      customItems: [10, 20, 30, 40, 50], // Mảng của combobox
      customItems2: ["Nhân bản", "Xóa", "Ngừng sử dụng"], // Mảng contextmenu
      allSelected: false,
      selectedtableDatas: [],
      employees: [],
      showEmployeeDetail: false,
      currentPage: 1, // Trang hiện tại
      pageSize: 10, // Kích thước trang
    };
  },
};
</script>

<style>
.first-left-content {
  display: flex;
  align-items: center;
}
.delete-row {
  text-decoration: none;
  display: flex;
  flex-direction: center;
  align-items: center;
  height: 36px;
  background-color: #eeeeee;
  padding: 0 12px;
  margin-left: 12px;
  border-radius: 4px;
  border: 1px solid #e0e0e0;
  width: max-content;
}
.delete-row > p:first-child {
  margin-right: 8px;
}
</style>
