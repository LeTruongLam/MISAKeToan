import { createRouter, createWebHistory } from "vue-router";
import EmployeeDetail from "@/views/employee/EmployeeDetail.vue";
import EmployeeList from "@/views/employee/EmployeeList.vue";

import CustomerList from "@/views/customer/CustomerList.vue";

// dinh nghia cac router
const routers = [
  {
    path: "/",
    name: "MisaHome",
    component: EmployeeList,
  },
  {
    path: "/employee",
    name: "EmployeeRouter",
    component: EmployeeList,
    children: [
      {
        path: "detail",
        name: "EmployeeDetailRouter",
        component: EmployeeDetail,
      },
    ],
  },

  {
    path: "/customer",
    name: "CustomerRouter",
    component: CustomerList,
  },
];
const vuerouter = createRouter({
  history: createWebHistory(),
  routes: routers,
});
export default vuerouter;
