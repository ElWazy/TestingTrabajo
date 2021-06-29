DROP TABLE IF EXISTS category;
CREATE TABLE category (
    uuid VARCHAR(36),
    name VARCHAR(50),

    PRIMARY KEY (uuid)
)
CHARACTER SET = 'utf8mb4'
COLLATE = 'utf8mb4_general_ci';