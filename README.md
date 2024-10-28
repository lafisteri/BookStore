# Setup MySql db in Docker

1. docker run --name my-mysql -e MYSQL_ROOT_PASSWORD=123456 -p 3306:3306 -d mysql:latest
2. docker exec -it my-mysql mysql -u root -p

3. CREATE DATABASE library;
4. USE library;
5. CREATE TABLE Books ( id INT AUTO_INCREMENT PRIMARY KEY, title VARCHAR(255) NOT NULL, author VARCHAR(255) NOT NULL, genre VARCHAR(100) );
6. INSERT INTO Books (title, author, genre) VALUES ('The Lord of the Rings', 'J. R. R. Tolkien', 'High fantasy');
