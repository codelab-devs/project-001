# 📘 MILESTONE 1 — TECHNICAL DOCUMENTATION

## Basic Echo Bot Implementation

### 1. Architecture

**Type:** Monolith Console Application
**Layerlar:**

- Bot Client Layer
- Update Handler
- Message Processor

---

### 2. Tech Stack

| Layer     | Technology   |
| --------- | ------------ |
| Language  | C#           |
| Framework | .NET 8       |
| Library   | Telegram.Bot |
| Hosting   | Console App  |

---

### 3. System Flow

1. Bot ishga tushadi
2. Polling orqali update kutadi
3. Text message aniqlanadi
4. Xabar userga qaytariladi

---

### 4. Models

**Incoming Telegram Model**

| Field     | Type   |
| --------- | ------ |
| MessageId | int    |
| ChatId    | long   |
| Text      | string |

---

### 5. API Interaction

Bot quyidagi methoddan foydalanadi:

- `GetUpdatesAsync()`
- `SendTextMessageAsync()`

---

### 6. Processing Logic

```
Agar update.Message.Text mavjud bo‘lsa
    SendTextMessage(chatId, text)
```

---

### 7. Logging

| Event            | Log               |
| ---------------- | ----------------- |
| Bot start        | "Bot started"     |
| Message received | Message text      |
| Error            | Exception message |

---

### 8. Error Handling

- Network xatolar try/catch bilan ushlanadi
- Null message skip qilinadi

---

### 9. Deployment

- Local run
- Token environment variable orqali beriladi

---

### 10. Risks

| Risk                 | Mitigation |
| -------------------- | ---------- |
| Telegram API timeout | Retry      |
| Invalid update       | Null check |

---

### 11. End Result

Bot user yuborgan xabarni qaytaradi va Telegram update handling jarayoni to‘liq ko‘rinadi.
