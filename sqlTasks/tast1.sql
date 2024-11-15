CREATE DATABASE miri2005


CREATE TABLE Authors (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL,
    Surname NVARCHAR(50) NOT NULL
);

CREATE TABLE Books (
    Id INT PRIMARY KEY IDENTITY,
    AuthorId INT NOT NULL,
    Name NVARCHAR(100) NOT NULL CHECK (LEN(Name) >= 2),
    PageCount INT NOT NULL CHECK (PageCount >= 10),
    FOREIGN KEY (AuthorId) REFERENCES Authors(Id)
);


CREATE VIEW BooksWithAuthors AS 
SELECT 
    b.Id AS BookId,
    b.Name AS BookName,
    b.PageCount,
    a.Name + ' ' + a.Surname AS AuthorFullName
FROM Books b
JOIN Authors a ON b.AuthorId = a.Id;


CREATE PROCEDURE SearchBooksByAuthorOrBookName
    @SearchTerm NVARCHAR(100)
AS
BEGIN
    SELECT 
        b.Id AS BookId,
        b.Name AS BookName,
        b.PageCount,
        CONCAT(a.Name, ' ', a.Surname) AS AuthorFullName
    FROM Books b
    JOIN Authors a ON b.AuthorId = a.Id
    WHERE b.Name LIKE '%' + @SearchTerm + '%'
       OR a.Name LIKE '%' + @SearchTerm + '%';
END;

/*EXEC SearchBooksByAuthorOrBookName @SearchTerm = 'miri';*/


CREATE FUNCTION GetBooksCountByMinPageCount
(
    @MinPageCount INT = 10
)
RETURNS INT
AS
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM Books
        WHERE PageCount > @MinPageCount
    );
END;

SELECT dbo.GetBooksCountByMinPageCount(50); 



