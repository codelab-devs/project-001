# 📘 MILESTONE 4 — TECHNICAL DOCUMENTATION

## Stateful Echo Bot Implementation

### 1. Architecture Update

System **layered architecture** ga o‘tadi:

**Bot Layer**
⬇
**Application Layer**
⬇
**Domain Layer**
⬇
**Infrastructure Layer (DB)**

---

### 2. Tech Stack

| Layer   | Technology |
| ------- | ---------- |
| DB      | PostgreSQL |
| ORM     | EF Core    |
| Pattern | Repository |

---

### 3. Database Schema

### Users

| Column     | Type   |
| ---------- | ------ |
| Id         | UUID   |
| TelegramId | bigint |

### MessageHistory

| Column | Type      |
| ------ | --------- |
| Id     | UUID      |
| UserId | UUID      |
| Text   | text      |
| Date   | timestamp |

Relation: **User 1 — N MessageHistory**

---

### 4. Processing Flow

1. Message keladi
2. User topiladi yoki yaratiladi
3. Message DB ga yoziladi
4. Router orqali process bo‘ladi
5. Javob yuboriladi

---

### 5. History Command Logic

```
Agar command == /history
    DB dan oxirgi message olinadi
    Userga qaytariladi
```

---

### 6. Repository Layer

| Method              | Purpose         |
| ------------------- | --------------- |
| GetUserByTelegramId | User topish     |
| AddMessage          | Message saqlash |
| GetLastMessage      | Oxirgi message  |

---

### 7. Risks

| Risk              | Mitigation     |
| ----------------- | -------------- |
| DB sekinlashishi  | Index qo‘shish |
| User topilmasligi | Auto-create    |

---

### 8. End Result

Bot endi:

- Userni tanlaydi
- Xabarlarni saqlaydi
- Oldingi suhbatni eslaydi
