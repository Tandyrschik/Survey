
# ������. 
1. ������� ������� � ����������, � ������� ����� ���������� ����������� �������, 
   ������ � ������� �������: `git clone https://github.com/Tandyrschik/Survey.git`
2. ��������� ������ ��� ������ ������� � ������� `docker-compose up`, 
   ��������� ���������� ������� � ������� �����������.

# Swagger, pgAdmin.
����� ������� ����������� ����� ��������� Swagger � pgAdmin � ��������.
1. Swagger: `https://localhost:8081/swagger/index.html`
2. pgAdmin: `http://localhost:5050/` (��� ����������������� �� ����� ��� ������� postgres@gmail.com � ������� 12345, 
������� ����� ������ � ������: postgres, host name/address: postgres, password: 12345)

# �������� ����������.
1. /survey(post) - ������� ����� �������� Survey � ���������� id ��������� ��������.
2. /question(post) - ������� ����� �������� Question � ���������� id ��������� ��������.
3. /question(get) - ����� �������� Question �� ��� Id.
4. /interview(post) - ������ ����� �������� Interview � ���������� ������ ������ �� ������.
5. /result(post) - ������ ����� �������� Result � ���������� id ���������� ������, ���� NoContent.

������ �������� ���� ������: Survey.API/query.txt