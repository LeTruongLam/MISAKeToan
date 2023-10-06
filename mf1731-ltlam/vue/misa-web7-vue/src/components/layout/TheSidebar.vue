<template>
  <div class="sidebar">
    <div class="sidebar-menu">
      <router-link to="/" class="sidebar-menu-item">
        <span class="icon icon-overview"></span>
        <span class="label">Tổng quan</span>
      </router-link>
      <router-link to="/employee"  class="sidebar-menu-item">
        <span class="icon icon-cash"></span>
        <span class="label">Tiền mặt</span>
      </router-link>
      <router-link to="/customer"  class="sidebar-menu-item">
        <span class="icon icon-deposits"></span>
        <span class="label">Tiền gửi</span>
      </router-link>
      <router-link to=""  class="sidebar-menu-item">
        <span class="icon icon-purchases"></span>
        <span class="label">Mua hàng</span>
      </router-link>
      <router-link to=""  class="sidebar-menu-item">
        <span class="icon icon-sales"></span>
        <span class="label">Bán hàng</span>
      </router-link>
      <a href="#" class="sidebar-menu-item">
        <span class="icon icon-order-management"></span>
        <span class="label">Quản lý đơn hàng</span>
      </a>
      <a href="#" class="sidebar-menu-item">
        <span class="icon icon-inventory"></span>
        <span class="label">Kho</span>
      </a>
      <a href="#" class="sidebar-menu-item">
        <span class="icon icon-tools"></span>
        <span class="label">Công cụ dụng cụ</span>
      </a>
      <a href="#" class="sidebar-menu-item">
        <span class="icon icon-taxes"></span>
        <span class="label">Thuế</span>
      </a>
    </div>
  </div>
</template>
<script>
export default {
  name: "TheSidebar",
};
</script>

<style></style>
