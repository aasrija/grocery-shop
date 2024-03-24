FROM python:latest
EXPOSE 5000
WORKDIR /app
RUN pip install Flask
CMD ["/bin/bash"]