<template>
   <div class="header-wrapper">
      <h1 class="title-main">Khách hàng</h1>
      <a href="#">
        <m-button
          content="Thêm mới nhân viên"
          @click="showEmployeeDetailFunction"
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
         
        </div>
        <div class="right-left-content">
          <m-search content="Tìm theo mã, tên nhân viên"></m-search>
          <i class="reload-icon"> </i>
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
            <tr v-for="tableData in tableDatas" :key="tableData.id">
              <td class="employee-table__data text-center size-checkbox">
                <input
                  type="checkbox"
                  id="myCheckbox"
                  :value="tableData.id"
                  v-model="selectedtableDatas"
                  @change="updateSelectedCount"
                />
              </td>
              <td class="employee-table__data">{{ tableData.id }}</td>
              <td class="employee-table__data">{{ tableData.name }}</td>
              <td class="employee-table__data">{{ tableData.gender }}</td>
              <td class="employee-table__data text-center">
                {{ formatDate(tableData.date) }}
              </td>
              <td class="employee-table__data">{{ tableData.phoneNumber }}</td>
              <td class="employee-table__data">{{ tableData.position }}</td>
              <td class="employee-table__data">{{ tableData.department }}</td>
              <td class="employee-table__data text-center">
                <div class="edit">
                  <a href="#">Sửa</a>
                  <a
                    href="#"
                    class="down-icon"
                    @click="toggleCombobox(tableData.id)"
                  >
                    <m-contextmenu
                      v-if="tableData.showCombobox"
                      :menuItems="customItems2"
                      @onClose="onCloseContextmenu"
                    ></m-contextmenu>
                  </a>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <div class="table-end">
        <div class="table-end-left">Tổng số <strong>80</strong> bản ghi</div>
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
            <a href="" class="right-icon-black"></a>
            <a href="" class="left-icon-black"></a>
          </div>
        </div>
      </div>
    </div>
</template>
<script>
export default {
  name: "TheEmployeeList",
  props: ["showEmployeeDetailFunction"],

  // Call data
  created() {
    // console.log("Lấy dữ liệu!")
    fetch("https://cukcuk.manhnv.net/api/v1/customers")
      .then((res) => res.json())
      .then((data) => {
        this.customers = data;
        // console.log(this.customers)
      });
  },

  computed: {
    // Trả về số checkbox đã được chọn
    selectedCount() {
      return this.selectedtableDatas.length;
    },

    // getSelectedtableDatas() {
    //   return this.tableDatas.filter((tableData) =>
    //     this.selectedtableDatas.includes(tableData.id)
    //   );
    // },
  },
  methods: {
    /**
     * Chuyển đổi trạng thái hiển thị của combobox cho một mục tableData cụ thể.
     * @param {number} id - Id của mục tableData.
     */
    toggleCombobox(id) {
      this.tableDatas.forEach((tableData) => {
        if (tableData.id === id) {
          tableData.showCombobox = !tableData.showCombobox;
        } else {
          tableData.showCombobox = false;
        }
      });
    },
    // Hàm định dạng ngày tháng
    formatDate(date) {
      try {
        date = new Date(date);
        let dateValue = date.getDate();
        let monthValue = date.getMonth() + 1;
        let year = date.getFullYear();
        return `${dateValue}/${monthValue}/${year}`;
      } catch (error) {
        console.error(error);
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

    // Chọn hết checkbox trong bảng
    selectAlltableDatas() {
      if (this.allSelected) {
        this.selectedtableDatas = this.tableDatas.map(
          (tableData) => tableData.id
        );
      } else {
        this.selectedtableDatas = [];
      }
    },
    // Cập nhật số checkbox đã chọn
    updateSelectedCount() {
      if (
        this.allSelected &&
        this.selectedtableDatas.length !== this.tableDatas.length
      ) {
        this.allSelected = false;
      }
      if (this.selectedtableDatas.length > 0) {
        this.showSelected = true;
      } else {
        this.showSelected = false;
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
      this.selectedtableDatas = this.tableDatas.map(
        (tableData) => tableData.id
      );
    },
  },
  data() {
    return {
      showCombobox: false,
      showContextMenu: false,
      showSelected: false,
      customItems: [10, 20, 30, 40, 50], // Mảng của combobox
      customItems2: ["Nhân bản", "Xóa", "Ngừng sử dụng"], // Mảng contextmenu
      allSelected: false,
      // Dữ liệu data
      tableDatas: [
        {
          id: "00001",
          name: "Nguyễn Văn Liệt",
          gender: "Nam",
          date: "2023-07-23T00:00:00",
          phoneNumber: "3535353535353",
          position: "Trưởng nhóm",
          department: "Vận hành Hà Nội",
        },
        {
          id: "00002",
          name: "Nguyễn Văn Liệt",
          gender: "Nam",
          date: "2023-07-21T00:00:00",
          phoneNumber: "3535353535353",
          position: "Trưởng nhóm",
          department: "Vận hành Hà Nội",
        },
        {
          id: "00003",
          name: "Nguyễn Văn Liệt",
          gender: "Nam",
          date: "2023-07-21T00:00:00",
          phoneNumber: "3535353535353",
          position: "Trưởng nhóm",
          department: "Vận hành Hà Nội",
        },
        {
          id: "00004",
          name: "Nguyễn Văn Liệt",
          gender: "Nam",
          date: "2023-07-21T00:00:00",
          phoneNumber: "3535353535353",
          position: "Trưởng nhóm",
          department: "Vận hành Hà Nội",
        },
        {
          id: "00005",
          name: "Nguyễn Văn Liệt",
          gender: "Nam",
          date: "2023-07-21T00:00:00",
          phoneNumber: "3535353535353",
          position: "Trưởng nhóm",
          department: "Vận hành Hà Nội",
        },
        {
          id: "00006",
          name: "Nguyễn Văn Liệt",
          gender: "Nam",
          date: "2023-07-21T00:00:00",
          phoneNumber: "3535353535353",
          position: "Trưởng nhóm",
          department: "Vận hành Hà Nội",
        },
        {
          id: "00007",
          name: "Nguyễn Văn Liệt",
          gender: "Nam",
          date: "2023-07-21T00:00:00",
          phoneNumber: "3535353535353",
          position: "Trưởng nhóm",
          department: "Vận hành Hà Nội",
        },
        {
          id: "00008",
          name: "Nguyễn Văn Liệt",
          gender: "Nam",
          date: "2023-07-21T00:00:00",
          phoneNumber: "3535353535353",
          position: "Trưởng nhóm",
          department: "Vận hành Hà Nội",
        },
        {
          id: "00009",
          name: "Nguyễn Văn Liệt",
          gender: "Nam",
          date: "2023-07-21T00:00:00",
          phoneNumber: "3535353535353",
          position: "Trưởng nhóm",
          department: "Vận hành Hà Nội",
        },
      ],
      selectedtableDatas: [],
      customers: [],
    };
  },
};
</script>

<style></style>
