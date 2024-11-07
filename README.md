# Setup
START
docker-compose build
docker-compose up

FINISH
docker-compose down

COMMANDS
GET http://localhost:8081/ - healtcheck
GET http://localhost:8081/api/books - Get all books
POST http://localhost:8081/api/books - Add a book
