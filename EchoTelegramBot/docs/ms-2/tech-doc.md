# 📘 MILESTONE 2 — TECHNICAL DOCUMENTATION

## Smart Echo Bot Implementation

### 1. Architecture Update

Oldingi milestone’dagi arxitekturaga yangi komponent qo‘shiladi:

**Bot Layer**  
↳ **Message Router**  
↳ **Command Handler**

---

### 2. Message Routing Strategy

Update quyidagicha tekshiriladi:

```
Agar Message.Text mavjud va "/" bilan boshlansa → Command Handler
Agar Message.Photo mavjud → Photo Handler
Agar Message.Sticker mavjud → Sticker Handler
Aks holda → Default Text Handler
```

---

### 3. Models

### User Model

| Field      | Type   |
| ---------- | ------ |
| TelegramId | long   |
| FirstName  | string |
| Username   | string |

---

### 4. API Interaction

Bot foydalanadigan methodlar:

- `SendTextMessageAsync()`
- `GetUpdatesAsync()`

---

### 5. Command Handling

| Command | Action                    |
| ------- | ------------------------- |
| /start  | Welcome message qaytaradi |

---

### 6. Response Logic

| Message Type | Response               |
| ------------ | ---------------------- |
| Text         | Echo                   |
| Photo        | “Siz rasm yubordingiz” |
| Sticker      | Sticker ID             |

---

### 7. Error Handling

- `update.Message == null` → skip
- Try/Catch har handler ichida
- Unknown type → default javob

---

### 8. Logging

| Event            | Log              |
| ---------------- | ---------------- |
| Command received | Command name     |
| Photo received   | Photo size count |
| Sticker received | Sticker ID       |

---

### 9. Risks

| Risk                              | Solution        |
| --------------------------------- | --------------- |
| Telegram update format o‘zgarishi | Null check      |
| Unknown message type              | Default handler |

---

### 🔟 End Result

Bot:

- Commandlarni tushunadi
- Message turini aniqlaydi
- Har xil kontentga mos javob beradi
