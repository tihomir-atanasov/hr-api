docker build -t api .
docker run -it --rm -p 5002:80 --name hr_api api