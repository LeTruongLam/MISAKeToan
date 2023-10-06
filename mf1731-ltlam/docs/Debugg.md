# DEBUGGING WITH VISUAL STUDIO
## Phím tắt:

Trước khi Debugging:

Ctrl + K, D: Format code
Ctrl + K, C: Comment code
Ctrl + K, U: Uncomment code
Ctrl + K, S: Đánh dấu Region (bôi đen code trước)
Ctrl + M, O: Gập code lại
Ctrl + M, P: Mở code ra
Ctrl + M, L: Toggle code
Ctrl + R + R: Đổi tên hàng loạt (có bôi đen)
Shift + Alt + .: Chọn thêm
Shift + Alt + ,: Chọn bớt
Shift + Alt + ;: Chọn tất cả
Ctrl + F: Tìm kiếm
Ctrl + Shift + F: Tìm kiếm hàng loạt
F12: Đi đến khai báo
Ctrl + F12: Go to Implementation
Ctrl + -: Navigate Backward
Ctrl + Shift + -: Navigate Forward
Chuẩn bị Debugging:

F9: Toggle Breakpoint
F5: Start with debugging
Ctrl + F5: Start without debugging
Ctrl + Alt + P (Process): Attach to process
Shift + Alt + P (Process): Reattach to process
Trong khi Debugging:

F5: Continue
Ctrl + Shift + B: Build
F11: Step Into
F10: Step Over
Shift + F11: Step Out
Ctrl + Shift + F10: Kéo con trỏ mà không chạy các lệnh ở giữa
F9 + F5 + F9: Combo Run To Cursor
Ctrl + F10: Run To Cursor
Mở cửa sổ:

Ctrl + Alt + I: Mở cửa sổ Immediate
Ctrl + Alt + C: Mở cửa sổ Call Stack
Ctrl + Alt + W + 1, 2, 3, 4: Mở cửa sổ 1, 2, 3, 4
(Ctrl + Alt + V) + A: Mở Auto
(Ctrl + Alt + V) + L: Mở Local
Ctrl + Alt + B: Mở cửa sổ quản lý Breakpoints

## Tự Debugg bản thân
##### Luồng chạy Debugg
- GetAllEmployeeAsync(){};
  + connectionString được gán Value ="Server=localhost; Port=3306; Database=MISADATA; Uid=root; Pwd=962002;", Type = "string".
  + connection có value = {MySqlConnector.MySqlConnection}.
  + sql có value ="SELECT * FROM Employee", Type = "string".
  + result có value = "Count = 13" số bản ghi trong Database

- GetEmployeeAsync(Guid employeeId){};
  + employeeId có Value = {3fa85f64-5717-4562-b3fc-2c963f66afa6} khi được nhập, Type = "Guid"
  + connectionString được gán Value ="Server=localhost; Port=3306; Database=MISADATA; Uid=root; Pwd=962002;", Type = "string".
  + connection có value = {MySqlConnector.MySqlConnection}.
  + sql có value =""SELECT * FROM Employee WHERE EmployeeId = '3fa85f64-5717-4562-b3fc-2c963f66afa6'"", Type = "string".
- DeleteEmployeeAsync(Guid employeeId){};
  + employeeId có Value = {3fa85f64-5717-4562-b3fc-2c963f66afa6} khi được nhập, Type = "Guid"
  + Tạo kết nối Database connectionString được gán Value ="Server=localhost; Port=3306; Database=MISADATA; Uid=root; Pwd=962002;", Type = "string".
  + Kiểm tra xem nhân viên có tồn tại hay không sqlCheckExistence được gán value = "SELECT COUNT(*) FROM Employee WHERE EmployeeId = '3fa85f64-5717-4562-b3fc-2c963f66afa6'", Type = "string"
  + employeeExists được trả về value = 1, Type = "int"
  + sql Delte thực hiện xóa EmployeeId value = "DELETE FROM employee WHERE EmployeeId = '3fa85f64-5717-4562-b3fc-2c963f66afa6'", Type = "string"