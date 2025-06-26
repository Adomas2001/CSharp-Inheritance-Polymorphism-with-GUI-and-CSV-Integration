# CSharp Inheritance & Polymorphism with GUI and CSV Integration

This project demonstrates the principles of **inheritance**, **polymorphism**, and **interface implementation** in C# using object-oriented programming. It includes a GUI (Windows Forms) and supports reading/writing data from and to `.csv` and `.txt` files. Data is stored using both system `List<T>` collections and custom dynamic containers.

---

## 📚 Features & Structure

### ✅ Core Object-Oriented Concepts

- **Base & Derived Classes**
  - Designed per task specification
  - Encapsulate shared and specialized behavior

- **Polymorphism**
  - Demonstrated through overridden virtual methods or interface-based invocation

- **Data Class**
  - Implements `IEquatable<T>` for equality checks
  - Implements `IComparable<T>` for sorting logic

- **Register Class**
  - Contains metadata and a reference to the main data container
  - Container can be:
    - `List<T>` (system dynamic array)
    - or a custom-built structure using a single internal array

### 📁 File Structure

- Each class is defined in a separate `.cs` file
- Utilities and logic are split into:
  - `IOUtils`: For file read/write (including `.csv`)
  - `TaskUtils`: For data processing and computation

---

## 🖥️ GUI Features (WinForms)

- `MenuStrip`: Main navigation and file controls
- `OpenFileDialog`: Load `.txt` or `.csv` data files
- `SaveFileDialog`: Choose where to save results
- `RichTextBox`, `ListBox`: For displaying structured results
- Partial class: `Form1.cs` for GUI logic

---

## 📊 Data Handling

- Supports both `.csv` and plain `.txt` formats
- Reads, displays, and saves data in tabular form
- Sorting:
  - Built-in `List<T>.Sort()` OR
  - Manually implemented Bubble Sort

---

## 🔄 Data Flow

1. Load input data using GUI (supports `.csv`)
2. Data parsed and loaded into the container
3. Process and sort using polymorphic logic
4. Display results in GUI and save to output file

---

## 🛠️ Technologies Used

- C# (.NET 6 / .NET Framework)
- Windows Forms (WinForms)
- Interfaces: `IEquatable<T>`, `IComparable<T>`
- Custom container implementation (optional)
- File I/O including `.csv` support

---

