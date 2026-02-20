# 📘 MILESTONE 3 — TECHNICAL DOCUMENTATION

## Filtered Echo Bot Implementation

### 1. Architecture Update

Oldingi arxitekturaga yangi qatlam qo‘shiladi:

**Bot Layer**
↳ **Middleware Layer**
↳ **Filter Service**

Middleware message’ni handlerga yetib borishidan oldin tekshiradi.

---

### 2. Processing Flow

1. Update keladi
2. Message Router orqali o‘tadi
3. **Filter Middleware** ishlaydi
4. Agar bloklansa → Warning
5. Aks holda → Echo handler

---

### 3. Models

### FilterRule Model

| Field   | Type                |
| ------- | ------------------- |
| Id      | int                 |
| Type    | enum (Word / Regex) |
| Pattern | string              |

---

### 4. Filtering Strategy

| Filter    | Implementation           |
| --------- | ------------------------ |
| Bad words | Blocked word list        |
| Links     | Regex (`http`, `www`)    |
| Caps      | `text == text.ToUpper()` |

---

### 5. Middleware Logic (Concept)

```
foreach rule in rules:
    if message matches rule:
        return BlockedResponse
return NextHandler
```

---

### 6. Response Handling

| Case    | Action            |
| ------- | ----------------- |
| Blocked | Warning message   |
| Allowed | Normal processing |

---

### 7. Extensibility

- FilterRule ro‘yxati kengaytiriladigan
- Yangi filter turi qo‘shish uchun service kengayadi

---

### 8. Risks

| Risk           | Mitigation               |
| -------------- | ------------------------ |
| False positive | Regex aniqligini sozlash |
| Performance    | Qisqa rule list          |

---

### 9. End Result

Bot endi:

- Moderatsiya qiladi
- Xabarlarni tekshiradi
- Zararlilarni bloklaydi
