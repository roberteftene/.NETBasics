using System;
using Xunit;

namespace GreenBook.Tests
{
    public class TypeTests
    {

        [Fact]
        public void StringsBehaveLikeValuesTypes() {
            string name = "Robert";
            var upper = MakeUpperCase(name);

            Assert.Equal("Robert",name);
        }

        private string MakeUpperCase(string parameter) {
           return parameter.ToUpper(); 
        }

        [Fact]
        public void CanSetNameFromReference()
        {
        //Given
        var book1 = GetBook("Book 1");
        
        //When
        book1.setName("New Name");

        //Then
        Assert.Equal("New Name", book1.getName());
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1",book1.getName());
            Assert.Equal("Book 2",book2.getName());
            Assert.NotSame(book1, book2);

        }

          [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1,book2));

        }

        Book GetBook(string name) {
            return new Book(name);
        }

    }
}
