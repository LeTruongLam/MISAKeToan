1. Khái niệm

- Để hiểu được Dependency Injection, cần phải hiểu Dependency Inversion và Inversion of Control Pattern trước.
*Dependency Inversion : là nguyên lý cuối cùng trong nguyên lý SOLID, trong đó:
    Các module cấp cao không nên phụ thuộc vào các modules cấp thấp. Cả 2 nên phụ thuộc vào abstraction.
    Interface (abstraction) không nên phụ thuộc vào chi tiết, mà ngược lại. ( Các class giao tiếp với nhau thông qua interface, không phải thông qua implementation.)
- Với cách code thông thường, các module cấp cao sẽ gọi các module cấp thấp. Module cấp cao sẽ phụ thuộc và module cấp thấp, điều đó tạo ra các dependency. Khi module cấp thấp thay đổi, module cấp cao phải thay đổi theo. Một thay đổi sẽ kéo theo hàng loạt thay đổi, giảm khả năng bảo trì của code.
- Nếu tuân theo Dependency Inversion principle, các module cùng phụ thuộc vào 1 interface không đổi. Ta có thể dễ dàng thay thế, sửa đổi module cấp thấp mà không ảnh hưởng gì tới module cấp cao.

*Inversion of Control

- Đây là một design pattern được tạo ra để code có thể tuân thủ nguyên lý Dependency Inversion. Có nhiều cách hiện thực pattern này: ServiceLocator, Event, Delegate, … Dependency Injection là một trong các cách đó.

*Dependency Injection (DI)

- Là một design pattern được ASP.Net hỗ trợ. Đây là một kỹ thuật để hiện thực hóa Inversion of Control Pattern (có thể coi nó là một design pattern riêng cũng được). Các module phụ thuộc (dependency) sẽ được inject vào module cấp cao. Có thể hiểu 1 cách đơn giản như sau:
    + Các module không giao tiếp trực tiếp với nhau, mà thông qua interface. Module cấp thấp sẽ implement interface, module cấp cao sẽ gọi module cấp thấp thông qua interface.
    + Ví dụ: Để giao tiếp với database, ta có interface IDatabase, các module cấp thấp là XMLDatabase, SQLDatabase. Module cấp cao là CustomerBusiness sẽ chỉ sử dụng interface IDatabase.
    + Việc khởi tạo các module cấp thấp sẽ do DI Container thực hiện. Ví dụ: Trong module CustomerBusiness, ta sẽ không khởi tạo IDatabase db = new XMLDatabase(), việc này sẽ do DI Container thực hiện. Module CustomerBusiness sẽ không biết gì về module XMLDatabase hay SQLDatabase.
    + Việc Module nào gắn với interface nào sẽ được config trong code hoặc trong file XML.
    + DI được dùng để làm giảm sự phụ thuộc giữa các module, dễ dàng hơn trong việc thay đổi module, bảo trì code và testing.
    => Đó là lý do tại sao cần sử dụng Dependency Injection

2. Các loại Dependency Injection
    + Constructor injection: Các dependency (biến phụ thuộc) được cung cấp thông qua constructor (hàm tạo lớp).
    + Setter injection: Các dependency sẽ được truyền vào 1 class thông qua các setter method (hàm setter).
    + Interface injection: Dependency sẽ cung cấp một Interface, trong đó có chứa hàm có tên là Inject. Các client phải triển khai một Interface mà có một setter method dành cho việc nhận dependency và truyền nó vào class thông qua việc gọi hàm Inject của Interface đó.

- Trong ba kiểu Inject thì Inject qua phương thức khởi tạo rất phổ biến vì tính linh hoạt, mềm dẻo, dễ xây dựng thư viện DI...

3. Ưu, khuyết điểm của Dependency Injection
*Ưu điểm

- Giảm sự kết dính giữa các module
- Code dễ bảo trì, dễ thay thế module
- Rất dễ test và viết Unit Test
- Dễ dàng thấy quan hệ giữa các module (Vì các dependency đều được inject vào constructor)

* Khuyết điểm

- Khái niệm DI khá “khó tiêu”, các developer mới sẽ gặp khó khăn khi học
- Sử dụng interface nên đôi khi sẽ khó debug, do không biết chính xác module nào được gọi
- Các object được khởi tạo toàn bộ ngay từ đầu, có thể làm giảm performance
- Làm tăng độ phức tạp của code

4. Tại sao phải dùng Dependency Injection ? Khi nào dùng tới nó ? Thực hiện nó ra sao ?

- Dependency Injection có thể được thực hiện dựa trên các quy tắc sau:

    + Các class sẽ không phụ thuộc trực tiếp lẫn nhau mà thay vào đó chúng sẽ liên kết với nhau thông qua một Interface hoặc base class (đối với một số ngôn ngữ không hỗ trợ Interface)
    + Việc khởi tạo các class sẽ do các Interface quản lí thay vì class phụ thuộc nó

- Giả sử, chúng ta có một class Car, trong đó có vài object khác như Wheel, hay Battery:

        class Car{
        private Wheels wheel = new MRFWheels();
        private Battery battery = new ExcideBattery();
        ...
        ...
        }

- Ở đây, class Car chịu trách nhiệm khởi tạo tất cả các dependency object. Nhưng chuyện gì sẽ xảy ra nếu chúng ta muốn bỏ MRFWheels và thay thế bằng BMWWheels.

- Lúc này chúng ta phải tạo lại đối tượng car mới với phụ thuộc mới (new dependecy) là BMWWheels. Rồi sau này nữa, bạn lại muốn độ bánh xe lên, hay thay bánh khác thì sao??? Mỗi lần vậy thêm một loạt code và khi đó chưa chắc chúng đã chạy được, chưa kể là cực kỳ khó đọc.

- Dependency Injection là một dạng design pattern được thiết kế nhằm ngăn chặn sự phụ thuộc nêu trên, khi sử dụng dependency injection, chúng ta có thể đổi wheel ở runtime vì dependency có thể được truyền vào (inject) ở runtime thay vì complile time, điều này giúp giảm chi phí trong việc sửa đổi và nâng cấp hệ thống. Nhờ vậy khi bạn thực thiện thay đổi một class A thì những class chứa biến kiểu class A cũng không cần phải thay đổi theo. 

- Bạn có thể hiểu là dependency injection là một người trung gian chịu trách nhiệm tạo ra các loại wheel khác nhau, rồi cung cấp chúng cho class Car. Việc đó làm cho class Car ko phải phụ thuộc vào Wheels cụ thể nào hay Battery cụ thể nào nữa.

        class Car{
        private Wheels wheel;
        private Battery battery;
        
        /*Ở đâu đó trong project, ta khởi tạo những objects mà đc yêu cầu bởi class này
            Có 2 cách để implement dependency injection
            1. Dựa vào constructor
            2. Dựa vào Setter method
        */
        
        // Dựa vào constructor
        Car(Wheel wh, Battery bt) {
            this.wh = wh;
            this.bt = bt;
        }
        
        // Dựa vào Setter method
        void setWheel(Batter bt){
            this.bt = bt;
        }
        ...  
        ...
        }