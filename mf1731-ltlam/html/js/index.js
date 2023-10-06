/**
 * Hàm mở Popup
 */

function openPopup() {
  var openpopup = document.getElementById("add");
  openpopup.style.display = "block";
}
/**
 * Hàm đóng Popup
 */

function closePopup() {
  var closepopup = document.getElementById("add");
  closepopup.style.display = "none";
}

/**
 * Hàm thông báo cảnh báo
 */

function openWarning() {
  var openwarning = document.getElementById("warning");
  var openpopup = document.getElementById("add");
  openwarning.style.display = "flex";
  openwarning.style.zIndex = "10000";
  openpopup.style.zIndex = "999";
}
/**
 * Hàm đóng thông báo cảnh báo
 */

function closeWarning() {
  var closewarning = document.getElementById("warning");
  closewarning.style.display = "none";
}

function openCombobox() {
  var opencombobox = document.getElementById("combobox");
  opencombobox.style.display = "block";
}

function openContextmenu() {
  var opencontextmenu = document.querySelector(".contextmenu");
  opencontextmenu.style.display = "block";
}
function openValidate() {
  var openvalidate = document.querySelector(".validate-form");
  openvalidate.style.display = "block";
}

function openExclamation() {
  var openexclamation = document.getElementById("exclamation");
  var openpopup = document.getElementById("add");
  openexclamation.style.display = "flex";
  openexclamation.style.zIndex = "10000";
  openpopup.style.zIndex = "999";
}

function closeExclamation() {
  var closeexclamation = document.getElementById("exclamation");
  closeexclamation.style.display = "none";
}
function openQuestion() {
  var openquestion = document.getElementById("question");
  var openpopup = document.getElementById("add");
  openquestion.style.display = "flex";
  openquestion.style.zIndex = "10000";
  openpopup.style.zIndex = "999";
}
function closeQuestion() {
  var closequestion = document.getElementById("question");
  closequestion.style.display = "none";
}

function successPopup() {
  var successpopup = document.getElementById("success");
  successpopup.style.zIndex = "10000000";
  setTimeout(function () {
    successpopup.style.zIndex = "-10000000";
  }, 2000);
}
