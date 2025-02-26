drop database if exists hospital;
create database if not exists hospital;

use hospital;

create table if not exists patients(
id_patient int primary key auto_increment,
firstname char(255) not null,
lastname char(255) not null,
phone char(255) not null,
birthday date not null,
adress char(255) not null
);

create table if not exists doctors(
id_doctor int primary key auto_increment,
firstname char(255) not null,
lastname char(255) not null,
phone char(255) not null,
birthday date not null
); 

create table if not exists departments (
id_department int primary key auto_increment,
department_name char(255) not null
);

create table if not exists doctors_departments (
id_doctors_department int primary key auto_increment,
doctor_id int not null,
department_id int not null,
foreign key (doctor_id) references doctors (id_doctor),
foreign key (department_id) references departments (id_department)
);

create table if not exists appointments (
id_appointments int primary key auto_increment,
appointment_date datetime not null,
doctor_id int not null,
patient_id int not null,
foreign key (doctor_id) references doctors (id_doctor),
foreign key (patient_id) references patients (id_patient)
);



create table if not exists users_roles (
id_role int primary key auto_increment,
role_name char(255) not null
);

create table if not exists users (
id_user int primary key auto_increment,
username char(255) not null,
passw char(255) not null,
role_id int not null,
doctor_id int,
foreign key (role_id) references users_roles (id_role),
foreign key (doctor_id) references doctors (id_doctor)
);





INSERT INTO departments (id_department, department_name) VALUES (1, 'Хирургия');
INSERT INTO departments (id_department, department_name) VALUES (2, 'Терапия');
INSERT INTO departments (id_department, department_name) VALUES (3, 'Педиатрия');
INSERT INTO departments (id_department, department_name) VALUES (4, 'Кардиология');
INSERT INTO departments (id_department, department_name) VALUES (5, 'Офтальмология');


INSERT INTO doctors (id_doctor, firstname, lastname, phone, birthday) VALUES (1, 'Регина', 'Ситникова', '79937829036', '1982-06-26');
INSERT INTO doctors (id_doctor, firstname, lastname, phone, birthday) VALUES (2, 'Стефан', 'Горбачёв', '79678175631', '1980-12-08');
INSERT INTO doctors (id_doctor, firstname, lastname, phone, birthday) VALUES (3, 'Любовь', 'Борисова', '79250949783', '1995-06-06');
INSERT INTO doctors (id_doctor, firstname, lastname, phone, birthday) VALUES (4, 'Владимир', 'Воронов', '79284786963', '1985-08-28');
INSERT INTO doctors (id_doctor, firstname, lastname, phone, birthday) VALUES (5, 'Марат', 'Казаков', '79900146716', '1988-04-29');
INSERT INTO doctors (id_doctor, firstname, lastname, phone, birthday) VALUES (6, 'Любовь', 'Соболева', '79866388970', '1989-11-01');
INSERT INTO doctors (id_doctor, firstname, lastname, phone, birthday) VALUES (7, 'Игнатий', 'Лапин', '79285469117', '1988-08-21');
INSERT INTO doctors (id_doctor, firstname, lastname, phone, birthday) VALUES (8, 'Рафаил', 'Щербаков', '79343622298', '1994-11-21');
INSERT INTO doctors (id_doctor, firstname, lastname, phone, birthday) VALUES (9, 'Ника', 'Коновалова', '79089778932', '1990-05-31');


INSERT INTO patients (id_patient, firstname, lastname, phone, birthday, adress) VALUES (1, 'Елена', 'Молчанова', '79274073787', '1985-09-06', 'ул. Ленина, д. 35, кв. 10, Москва');
INSERT INTO patients (id_patient, firstname, lastname, phone, birthday, adress) VALUES (2, 'Нонна', 'Сидорова', '79253775541', '1985-11-26', 'пр. Мира, д. 83, Питер');
INSERT INTO patients (id_patient, firstname, lastname, phone, birthday, adress) VALUES (3, 'Клара', 'Сазонова', '79018401711', '2011-11-03', 'ул. Пушкина, д. 71, кв. 2, Екатеринбург');
INSERT INTO patients (id_patient, firstname, lastname, phone, birthday, adress) VALUES (4, 'Семён', 'Зайцев', '79511209097', '2003-05-19', 'ул. Чапаева, д. 55, Кемерово');
INSERT INTO patients (id_patient, firstname, lastname, phone, birthday, adress) VALUES (5, 'Антонина', 'Блинова', '79297662017', '2017-01-11', 'ул. Гагарина, д. 46, кв. 34, Новосибирск');
INSERT INTO patients (id_patient, firstname, lastname, phone, birthday, adress) VALUES (6, 'Екатерина', 'Сафонова', '79589312854', '2000-08-26', 'ул. Тимирязева, д. 70, Бердск');
INSERT INTO patients (id_patient, firstname, lastname, phone, birthday, adress) VALUES (7, 'Степан', 'Ефимов', '79440581689', '1997-10-23', 'ул. Лермонтова, д. 55, кв. 12, Казань');
INSERT INTO patients (id_patient, firstname, lastname, phone, birthday, adress) VALUES (8, 'Дан', 'Романов', '79947855381', '1994-08-29', 'ул. Невского, д. 6, Главная, Самара');
INSERT INTO patients (id_patient, firstname, lastname, phone, birthday, adress) VALUES (9, 'Василий', 'Беспалов', '79467846784', '2003-09-11', 'ул. Мира, д. 16, кв. 111, Калуга');
INSERT INTO patients (id_patient, firstname, lastname, phone, birthday, adress) VALUES (10, 'Трофим', 'Комаров', '79799696621', '1992-11-22', 'ул. Степана Разина, д. 73, сыйв. 072, Ростов-на-Дону');


INSERT INTO `users_roles` (`id_role`, `role_name`) VALUES (1, 'администратор');
INSERT INTO `users_roles` (`id_role`, `role_name`) VALUES (2, 'врач');


INSERT INTO `users` (`id_user`, `username`, `passw`, `role_id`, doctor_id) VALUES (1, 'd1', 'kvakva', 2,3);
INSERT INTO `users` (`id_user`, `username`, `passw`, `role_id`, doctor_id) VALUES (2, 'd2', 'kvakva', 2,2);
INSERT INTO `users` (`id_user`, `username`, `passw`, `role_id`) VALUES (3, 'admin', 'kvakva', 1);
INSERT INTO `users` (`id_user`, `username`, `passw`, `role_id`, doctor_id) VALUES (4, 'd3', 'kvakva', 2,5);
INSERT INTO `users` (`id_user`, `username`, `passw`, `role_id`, doctor_id) VALUES (5, 'd4', 'kvakva', 2,1);
INSERT INTO `users` (`id_user`, `username`, `passw`, `role_id`, doctor_id) VALUES (6, 'd5', 'kvakva', 2,4);
INSERT INTO `users` (`id_user`, `username`, `passw`, `role_id`, doctor_id) VALUES (7, 'd6', 'kvakva', 2,9);
INSERT INTO `users` (`id_user`, `username`, `passw`, `role_id`, doctor_id) VALUES (8, 'd7', 'kvakva', 2,8);
INSERT INTO `users` (`id_user`, `username`, `passw`, `role_id`, doctor_id) VALUES (9, 'd8', 'kvakva', 2,6);
INSERT INTO `users` (`id_user`, `username`, `passw`, `role_id`, doctor_id) VALUES (10, 'd9', 'kvakva', 2,7);






















