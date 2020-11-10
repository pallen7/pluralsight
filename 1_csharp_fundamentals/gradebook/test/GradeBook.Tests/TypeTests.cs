using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Paul";
            var upper = MakeUppercase(name);

            Assert.Equal("Paul", name);
            Assert.Equal("PAUL", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void PassAValueTypeByReference()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int z) // z is just a reference (pointer) to x so we can update it
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = new Book("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = new Book("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            // the book parameter references our outer book but it's value is just a copy of the pointer held in the
            // calling book1 variable.
            book = new Book(name); // This changes the pointer value in book so it doesn't point to our calling Book
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = new Book("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2  = book1;

            // Assert that 2 objects are the same instance
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2)); // This is the equivalent of the above
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
