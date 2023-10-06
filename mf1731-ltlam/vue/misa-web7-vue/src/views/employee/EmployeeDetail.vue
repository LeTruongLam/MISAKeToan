<template>
  <div id="add" class="form-hide">
    <div class="form-container">
      <div class="form-content">
        <div class="form-wrapper">
          <div class="title-form">
            <div class="title-form-left">
              <h1>Thông tin nhân viên</h1>
              <p>
                <input type="checkbox" id="myCheckbox" checked />
                <label for="">Là khách hàng</label>
              </p>
              <p>
                <input type="checkbox" id="myCheckbox" />
                <label for="">Là nhà cung cấp</label>
              </p>
            </div>

            <div class="title-form-right">
              <div class="question-icon"></div>
              <a @click="onCloseForm">
                <div class="close-icon"></div>
              </a>
            </div>
          </div>
          <div class="form-content-main">
            <div class="employee-infor">
              <div class="input-form">
                <div class="input-row">
                  <div class="employee-id">
                    <p class="text-boil">
                      Mã
                      <span>*</span>
                    </p>

                    <div class="search-bar">
                      <input
                        tabindex="1"
                        id="txtId"
                        type="text"
                        placeholder=""
                        v-model="employee.EmployeeCode"
                      />
                    </div>
                    <label class="validate-form">{{
                      employee.EmployeeCode
                    }}</label>
                  </div>
                  <div class="employee-name">
                    <p class="text-boil">
                      Tên
                      <span>*</span>
                    </p>

                    <div class="search-bar">
                      <input
                        tabindex="2"
                        type="text"
                        placeholder=""
                        v-model="employee.FullName"
                      />
                    </div>
                    <label class="validate-form">{{ employee.FullName }}</label>
                  </div>
                </div>
              </div>
              <div class="input-form">
                <m-input
                  title="Đơn vị"
                  :tabIndex="6"
                  :showNote="true"
                  :showTitle="true"
                  :showIcon="true"
                ></m-input>
                <!-- <ms-combobox  style="width:100%"
                url="https://localhost:7102/api/v1/Employees"
                propText="DepartmentName"
                propValue="EmployeeId"
                >
                </ms-combobox> -->
              </div>
              <div class="input-form">
                <m-input
                  title="Chức danh"
                  :tabIndex="10"
                  :showNote="false"
                  :showTitle="true"
                  :showIcon="false"
                ></m-input>
              </div>
            </div>
            <div class="employee-infor-right">
              <div class="input-form">
                <div class="input-row">
                  <div class="employee-id">
                    <p class="text-boil">Ngày sinh</p>
                    <div class="search-bar">
                      <input
                        type="date"
                        placeholder="dd/mm/yyyy"
                        tabindex="3"
                        v-model="employee.DateOfBirth"
                      />
                      <!-- <label for="search-box" class="date-icon"></label> -->
                    </div>
                  </div>
                  <div class="employee-name">
                    <p class="text-boil">Giới tính</p>
                    <div class="radio-row">
                      <span>
                        <input
                          type="radio"
                          name="gender"
                          tabindex="3"
                          value="0"
                          v-model="employee.Gender"
                          checked
                        />
                        <label for="">Nam</label>
                      </span>
                      <span>
                        <input
                          type="radio"
                          name="gender"
                          tabindex="4"
                          value="1"
                          v-model="employee.Gender"
                        />
                        <label for="">Nữ</label>
                      </span>
                      <span>
                        <input
                          type="radio"
                          name="gender"
                          tabindex="5"
                          value="2"
                          v-model="employee.Gender"
                        />
                        <label for="">Khác</label>
                      </span>
                    </div>
                  </div>
                </div>
              </div>
              <div class="input-form">
                <div class="input-row">
                  <div class="employee-name">
                    <p class="text-boil">
                      <label title="Số chứng minh nhân dân">Số CMND</label>
                    </p>
                    <div class="search-bar">
                      <input type="text" placeholder="" tabindex="8" />
                    </div>
                  </div>

                  <div class="employee-id">
                    <p class="text-boil">Ngày cấp</p>
                    <div class="search-bar">
                      <!-- <input type="date" placeholder="dd/mm/yyyy" /> -->
                      <input
                        type="text"
                        placeholder="dd/mm/yyyy"
                        tabindex="9"
                      />
                      <label for="search-box" class="date-icon"></label>
                    </div>
                  </div>
                </div>
              </div>
              <div class="input-form">
                <m-input
                  title="Nơi cấp"
                  :tabIndex="11"
                  :getValue="getValueInput"
                  :showNote="false"
                  :showTitle="true"
                  :showIcon="false"
                ></m-input>
              </div>
            </div>
          </div>
          <div class="employee-address">
            <div class="input-form">
              <m-input
                title="Địa chỉ"
                :tabIndex="12"
                :getValue="getValueInput"
                :showNote="false"
                :showTitle="true"
                :showIcon="false"
              ></m-input>
            </div>
            <div class="input-form">
              <div class="input-row">
                <div class="employee-id">
                  <p class="text-boil">Điện thoại di động</p>

                  <!-- <div class="search-bar">
                    <input
                      tabIndex="13"
                      type="text"
                      placeholder=""
                      v-model="employee.PhoneNumber"
                    />
                  </div> -->
                </div>

                <div class="employee-id">
                  <p class="text-boil">Email</p>

                  <div class="search-bar">
                    <input
                      tabIndex="14"
                      type="text"
                      placeholder=""
                    />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="buttons">
          <a href="#" class="button-left">
            <a @click="onCloseForm" tabIndex="15">
              <m-button class="button-white" content="Hủy"></m-button>
            </a>
          </a>
          <div class="buttom-right">
            <a tabIndex="16">
              <m-button
                class="button-white"
                @click="onSave"
                content="Cất"
              ></m-button
            ></a>
            <a href="#" tabIndex="17">
              <m-button
                class="m-left-20"
                @click="onSaveAdd"
                content="Cất và thêm"
              ></m-button>
            </a>
          </div>
        </div>
      </div>
    </div>
  </div>
  <m-dialog
    v-if="showDialog"
    :title="$MISAEnum['MISADialog'].Warning.title"
    :type="$MISAEnum['MISADialog'].Warning.id"
    :content="contentDialog"
    @onClose="onCloseDialog"
  >
  </m-dialog>
  <m-notify
    v-if="showNotify"
    :title="titleNotify"
    :type="iconNotify"
    :message="contentNotify"
  ></m-notify>
</template>
<script>
export default {
  name: "TheEmployeeDettail",
  props: [""],
  mounted() {
    // Tự đôngj focus vào input
    document.getElementById("txtId").focus();
  },
  methods: {
    getValueInput(value) {
      // Nhận giá trị từ component con và gán cho inputValue trong component cha
      this.inputValue = value;
      console.log(this.inputValue);
    },
    //Đóng form
    onCloseForm() {
      this.$emitter.emit("onClose");
    },
    // Mở Dialog
    onShowDialog() {
      this.showDialog = true;
    },
    // Đóng Dialog
    onCloseDialog() {
      this.showDialog = false;
    },
    // Hiện thông báo và ẩn trong 5 giây
    onShowNotify() {
      this.showNotify = true;
      setTimeout(() => {
        this.showNotify = false;
      }, 5000);
    },
    // Thêm và cất
    // Hiển thị thông báo và làm mới input
    onSaveAdd() {
      this.onSave();
      // this.employee.EmployeeCode = "";
      // this.employee.FullName = "";
      // this.employee.Email = "";
      // this.employee.PhoneNumber = "";
      document.getElementById("txtId").focus();
    },
    // Lưu thông tin
    // HIển thị thông báo
    onSave() {
      this.mapGenderValue(this.employee.Gender);
      this.$axios
        .post(`https://localhost:7102/api/v1/Employees`, this.employee)
        .then((res) => {
          console.log("OK: ", res);
          this.$emit("saveSuccess");
        })
        .catch((error) => {
          console.log("error: ", this.employee);

          this.onShowErrorHandle(error);
          console.log("error: ", error);
        });
    },

    // Hiện thông báo lỗi và show mã lỗigit
    onShowErrorHandle(error) {
      const code = error.response.status;
      const msg = error.response.data.userMsg;
      this.onShowDialog();
      this.contentDialog = msg;
      console.log("Code: ", code);
    },
    mapGenderValue(value) {
      if (value === "0") {
        return (this.employee.Gender = this.$MISAEnum.Gender.Male);
      } else if (value === "1") {
        return (this.employee.Gender = this.$MISAEnum.Gender.Female);
      } else {
        return (this.employee.Gender = this.$MISAEnum.Gender.Other);
      }
    },
  },
  data() {
    return {
      contentDialog: "",
      showDialog: false,
      inputValue: "",
      validate: true,
      showNotify: false,
      employee: {
        EmployeeCode: "",
        FullName: "",
        // PhoneNumber: "",
        DateOfBirth: "",
        Gender: "0",
        // CreatedBy:"",
        // CreatedDate: "",
        // ModifiedBy:"",
        // ModifiedDate:""
      },
    };
  },
};
</script>

<style>
.m-left-20 {
  margin-left: 8px;
}
</style>
