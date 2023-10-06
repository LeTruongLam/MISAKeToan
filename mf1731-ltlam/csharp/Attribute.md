- Trong lập trình C# .NET, attribute là những đoạn mã được gắn vào các phần tử trong mã nguồn (ví dụ: lớp, phương thức, biến, ...) để cung cấp thông tin bổ sung hoặc chỉ định cho chúng. Attribute đóng vai trò quan trọng trong quá trình biên dịch, xây dựng và chạy ứng dụng.
- Trong C#, attribute (Thuộc tính) là thông tin bổ sung cho các thành phần của một class.
- Attribute là một cách để thêm metadata (dữ liệu mô tả) vào các thành phần của chương trình, chẳng hạn như lớp (class), phương thức (method), thuộc tính (property) và các thành phần khác.
- Các attribute có thể được sử dụng để chỉ định các tính chất bổ sung cho các thành phần của chương trình, ví dụ như tên, mô tả, độ ưu tiên, hoặc để giúp cho trình biên dịch hiểu được một số thông tin cần thiết. Attribute cũng có thể được sử dụng để thêm các chức năng bổ sung cho các thành phần của chương trình, ví dụ như kiểm tra lỗi, quản lý phiên bản, hoặc tạo ra mã máy tùy chỉnh.

- Các thuộc tính của Attribute:
Attribute có thể có các đối số tương tự như các phương thức, thuộc tính, v.v. có thể có đối số.
Attribute có thể có từ không đến nhiều tham số.
Các phần tử mã khác nhau như phương thức, assembly, thuộc tính, kiểu, v.v. có thể có một hoặc nhiều attribute.
Reflection (phản chiếu) có thể được sử dụng để lấy thông tin về metadata của chương trình bằng cách truy cập vào các attribute trong thời gian chạy.
Attribute thường được dẫn xuất từ lớp System.Attribute.
- Các thuộc tính giúp cho việc phát triển ứng dụng trở nên dễ dàng hơn bằng cách cung cấp thông tin và chỉ định rõ ràng cho các phần tử trong mã nguồn. Ví dụ, khi sử dụng thuộc tính [Serializable] cho một lớp, ta có thể chỉ định rằng lớp đó có thể được chuyển đổi thành dạng dữ liệu có thể lưu trữ hoặc truyền qua mạng. Các thuộc tính khác như [Obsolete], [DllImport], [Conditional],... cũng đóng vai trò quan trọng trong việc chỉ định hành vi của mã nguồn và giúp cho việc phát triển ứng dụng trở nên hiệu quả hơn.
- Ngoài ra, các thuộc tính còn được sử dụng trong quá trình phát triển và triển khai các thư viện, framework, SDK, giúp cho việc sử dụng các công cụ này trở nên dễ dàng hơn bằng cách cung cấp thông tin chi tiết về các phương thức, lớp hay các chức năng có thể sử dụng được. Do đó, thuộc tính là một thành phần quan trọng trong lập trình C# .NET.
- Các loại Attribute trong C#.
Một số attribute tích hợp sẵn trong C#:

1. [Obsolete]: Đánh dấu một phương thức, lớp hoặc thuộc tính đã bị lỗi thời và không nên được sử dụng trong mã nguồn mới.
2. [Serializable]: Đánh dấu một lớp có thể được serialize và deserialize thành các đối tượng, để lưu trữ hoặc truyền tải giữa các ứng dụng khác nhau.
3. [DllImport]: Đánh dấu một phương thức tĩnh mà được triển khai bởi một thư viện động bên ngoài.
4. [Conditional]: Đánh dấu một phương thức để chỉ định điều kiện biên dịch, khi được đánh dấu, phương thức chỉ được biên dịch khi điều kiện được đưa ra.
5. [AttributeUsage]: Đánh dấu một attribute để chỉ định cách sử dụng attribute, bao gồm cách sử dụng, số lần sử dụng, và các đối tượng được áp dụng attribute.
6. [MethodImpl]: Đánh dấu một phương thức để chỉ định cách thức triển khai của nó, bao gồm phương thức nội tại, đồng bộ hóa và các tùy chọn triển khai khác.
7. [Serializable]: Đánh dấu một lớp có thể được serialize và deserialize thành các đối tượng, để lưu trữ hoặc truyền tải giữa các ứng dụng khác nhau.

Attribute tự tạo:
- Custom Attribute trong C# .NET là một cách để bạn có thể định nghĩa thêm các thông tin meta-data cho một lớp, một thuộc tính, một phương thức hay một tham số. Các attribute này có thể được sử dụng để cung cấp thông tin cho các công cụ như trình biên dịch, trình giải mã, hoặc để đánh dấu các vị trí quan trọng trong mã nguồn.
- Để tạo một custom attribute, bạn cần phải tạo một lớp mới, kế thừa từ Attribute class, và ghi đè các thuộc tính và phương thức của nó theo ý muốn. Ví dụ, sau đây là một custom attribute đơn giản:

[AttributeUsage(AttributeTargets.Class)]
public class MyCustomAttribute : Attribute
{
    public string Description { get; set; }
    public MyCustomAttribute(string description)
    {
        Description = description;
    }
}
- Trong ví dụ này, chúng ta đã tạo một custom attribute có tên là "MyCustomAttribute” và thuộc tính "Description” kiểu chuỗi. Ngoài ra, chúng ta đã sử dụng AttributeUsage attribute để chỉ định rằng MyCustomAttribute chỉ được áp dụng cho các lớp (AttributeTargets.Class).
Để sử dụng custom attribute này, bạn có thể áp dụng nó cho một lớp bằng cách sử dụng củ pháp sau:

[MyCustom("This is a custom attribute")]
public class MyClass
{
    // ...
}
Sau đó, bạn có thể truy xuất thông tin của custom attribute bằng cách sử dụng reflection. Ví dụ:

Type type = typeof(MyClass);
MyCustomAttribute attribute = (MyCustomAttribute)type.GetCustomAttributes(typeof(MyCustomAttribute), true)[0];
Console.WriteLine(attribute.Description); // Output: "This is a custom attribute"


- Kết luận : 
Attribute là một tính năng quan trọng của C# và .NET Framework. Attribute là các cụm thông tin được gắn liền với các khai báo trong mã nguồn C#, ví dụ như các lớp, phương thức, thuộc tính, trường, tham số, v.v. Các attribute có thể được sử dụng để cung cấp thông tin bổ sung cho các trình biên dịch, trình dịch ngược, trình đọc mã, các công cụ phân tích mã, hoặc các công cụ khác trong quá trình phát triển và triển khai phần mềm.

Tham khảo tại https://tuhocict.com/attribute-trong-c/#