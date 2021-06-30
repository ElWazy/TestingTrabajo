DROP TABLE IF EXISTS tool;
CREATE TABLE tool (
    uuid VARCHAR(36),
    name VARCHAR(50),
    category_id_fk VARCHAR(50),
    stock INT,
    real_stock INT,

    PRIMARY KEY (uuid),
    FOREIGN KEY (category_id_fk) REFERENCES category (uuid)
)
CHARACTER SET = 'utf8mb4'
COLLATE = 'utf8mb4_general_ci';