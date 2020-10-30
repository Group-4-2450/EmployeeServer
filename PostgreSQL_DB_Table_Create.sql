CREATE TYPE employee_position_types AS ENUM (
    'Executive',
    'Management',
    'Workers'
);

CREATE TYPE gender_types AS ENUM (
    'Female',
    'Male'
);

CREATE TYPE employee_relationship_tpyes AS ENUM (
    'Father',
    'Mother',
    'GrandFather',
    'GrandMother',
    'Brother',
    'Sister',
    'Cousin',
    'Uncle',
    'Aunt',
    'Other'
);

CREATE TYPE phone_types AS ENUM (
    'cell',
    'home',
    'work'
);

CREATE TABLE employee(
    id int PRIMARY KEY NOT NULL,
    employee_id int NOT NULL ,
    first_name varchar NOT NULL,
    last_name varchar NOT NULL,
    ssn varchar NOT NULL,
    phone_number varchar,
    birthdate varchar NOT NULL,
    title varchar NOT NULL,
    employee_position employee_position_types NOT NULL,
    gender gender_types,
    wage float,
    start_date varchar,
    home_address varchar NOT NULL,
    payment_information varchar NOT NULL
);

CREATE TABLE employee_expenses(
    id int NOT NULL,
    reimbursement float4 NOT NULL,
    card_number varchar NOT NULL,
    card_enabled bool NOT NULL,
    current_balance float4 NOT NULL,
    FOREIGN KEY (id) REFERENCES employee(id)
);

CREATE TABLE employee_emergency_contact(
    id int NOT NULL,
    first_name varchar NOT NULL,
    last_name varchar NOT NULL,
    phone_number varchar NOT NULL,
    phone_type phone_types NOT NULL,
    email varchar,
    relationship_to_employee employee_relationship_tpyes,
    FOREIGN KEY (id) REFERENCES employee(id)
);