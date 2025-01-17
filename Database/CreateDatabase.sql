CREATE TABLE profile (
    id SERIAL PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(50) NOT NULL,
    coins INT DEFAULT 20,
    elo INT DEFAULT 100,
    wins INT DEFAULT 0,
    losses INT DEFAULT 0,
    draws INT DEFAULT 0,
    bio VARCHAR(50),
    image VARCHAR(50),
    token VARCHAR(255)
);

CREATE TABLE card (
    id UUID PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    damage FLOAT NOT NULL,
    element_type VARCHAR(20) NOT NULL CHECK (element_type IN ('Fire', 'Water', 'Normal')),
    card_type VARCHAR(20) NOT NULL CHECK (card_type IN ('Monster', 'Spell'))
);

CREATE TABLE stack (
    user_id INT REFERENCES profile(id) ON DELETE CASCADE,
    card_id UUID REFERENCES card(id) ON DELETE CASCADE,
    PRIMARY KEY(user_id, card_id),
    in_deck BOOLEAN DEFAULT FALSE,
    in_store BOOLEAN DEFAULT FALSE
);

CREATE TABLE package (
    id SERIAL PRIMARY KEY
);

CREATE TABLE package_card (
    package_id INT REFERENCES package(id) ON DELETE CASCADE,
    card_id UUID REFERENCES card(id) ON DELETE CASCADE,
    PRIMARY KEY(package_id, card_id)
);

CREATE TABLE trade (
    id SERIAL PRIMARY KEY,
    card_id UUID REFERENCES card(id) ON DELETE CASCADE,
    required_type VARCHAR(20) NOT NULL CHECK (required_type IN ('Monster', 'Spell')),
    min_damage INT NOT NULL
);

CREATE TABLE deck (
    user_id INT REFERENCES profile(id) ON DELETE CASCADE,
    card_id UUID REFERENCES card(id),
    PRIMARY KEY(user_id, card_id)
);