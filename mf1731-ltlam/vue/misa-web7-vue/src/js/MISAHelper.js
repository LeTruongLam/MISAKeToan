const MISAHelper = {
  // Ham dinh danh ngay thang nam
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
 
};

export default MISAHelper;
