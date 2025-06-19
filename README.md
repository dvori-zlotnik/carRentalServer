# Car Rental - מערכת השכרת רכבים

מערכת End-to-End לניהול השכרת רכבים, הכוללת ממשק ניהול מתקדם, הרשאות, ניהול משתמשים, השכרות, ועוד.

## תכונות עיקריות

- **ניהול רכבים**: הוספה, עריכה, מחיקה וחיפוש רכבים.
- **ניהול משתמשים והרשאות**: הרשמה, התחברות, ניהול משתמשים עם רמות הרשאה (Admin, משתמש רגיל).
- **ניהול השכרות**: הזמנת רכב, החזרת רכב, היסטוריית השכרות.
- **ארכיטקטורת שכבות**: הפרדה בין שכבת נתונים (DAL), לוגיקה עסקית (BLL) וצד שרת (API).
- **הזרקת תלויות (Dependency Injection)**: כל השירותים, ה־DbContext, ומחלקות הלוגיקה העסקית מוזרקים אוטומטית לכל בקר (Controller) באמצעות מנגנון ה־DI של ASP.NET Core.
- **ביצועים גבוהים**: דגש על יעילות ומהירות תגובה.
- **עיצוב רספונסיבי**: מותאם לדסקטופ ולמובייל.
- **קוד נקי ומודולרי**: שמות משתנים ברורים, חלוקה לפונקציות, הקפדה על סטנדרטים.

## טכנולוגיות

- **Backend**:  
  - C# (.NET 7, ASP.NET Core)
  - Entity Framework Core
  - SQL Server
  - Dependency Injection (מובנה ב־ASP.NET Core)

- **Frontend**:  
  - React
  - Redux Toolkit
  - React Router
  - Material-UI (MUI)
  - Styled Components

## התקנה והרצה

### דרישות מוקדמות

- Node.js (להרצת צד לקוח)
- .NET 7 SDK
- SQL Server (מקומי או בענן)

### התקנת צד שרת

1. פתח את הפתרון ב-Visual Studio 2022.
2. עדכן את מחרוזת החיבור (`ConnectionStrings`) בקובץ `appsettings.json` לפי מסד הנתונים שלך.
3. הרץ את הפקודה:
   dotnet build dotnet ef database update dotnet run --project Car_rental/Car_rental.csproj
   
### התקנת צד לקוח

1. עבור לתיקיית ה-Client (React).
2. הרץ:
   npm install
   npm start
   
### שימוש

- השרת יאזין בברירת מחדל לכתובת `https://localhost:7067` (או לפי ההגדרות שלך).
- צד הלקוח יאזין בברירת מחדל ל-`http://localhost:3000`.

## הזרקת תלויות (Dependency Injection)

הפרויקט עושה שימוש מלא במנגנון ה־Dependency Injection של ASP.NET Core:
- כל השירותים (Services), מחלקות הלוגיקה העסקית (BLL), ושכבת הנתונים (DAL) נרשמים ב־DI Container.
- ה־DbContext (CarRentalContext) מוזרק אוטומטית לכל מחלקה שזקוקה לו.
- כל Controller מקבל את התלויות שלו דרך הבנאי, ללא יצירה ידנית של מופעים.

דוגמה לרישום שירותים ב־Program.cs:
builder.Services.AddDbContext<CarRentalContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

## תרומות

תרומות, הצעות ושיפורים יתקבלו בברכה!

---

**בהצלחה!**
