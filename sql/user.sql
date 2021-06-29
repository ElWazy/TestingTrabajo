DROP TABLE IF EXISTS employee;
CREATE TABLE employee (
    uuid VARCHAR(36),
    rut VARCHAR(13),
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(128),
    passwd VARCHAR(80),
    birth_date DATE,
    salary INT,
    profile_id_fk VARCHAR(36),

    PRIMARY KEY (uuid),
    FOREIGN KEY (profile_id_fk) REFERENCES profile (uuid)
)
CHARACTER SET = 'utf8mb4'
COLLATE = 'utf8mb4_general_ci';