¨App-Hexagonal/
│
├── src/
│   ├── App.Domain/
│   │   ├── Common/
│   │   │   └── DomainException.cs
│   │   └── student/
│   │       ├── model/
│   │       │   └── Student.cs
│   │       └── exception/
│   │           └── InvalidStudentAgeException.cs
│   │
│   ├── App.Application/
│   │   └── student/
│   │       ├── ports/
│   │       │   ├── input/
│   │       │   │   └── IStudentServicePort.cs
│   │       │   └── output/
│   │       │       └── IStudentPersistencePort.cs
│   │       └── service/
│   │           └── StudentService.cs
│   │
│   ├── App.Infrastructure/
│   │   ├── data/
│   │   │   └── ApplicationDbContext.cs
│   │   └── student/
│   │       └── ports/
│   │           └── output/
│   │               └── persistence/
│   │                   ├── entity/
│   │                   │   └── StudentEntity.cs
│   │                   ├── mapping/
│   │                   │   └── StudentPersistenceMapping.cs
│   │                   └── repository/
│   │                       └── StudentPersistenceAdapter.cs
│   │
│   └── App.Api/
│       ├── Controllers/
│       │   └── StudentController.cs
│       ├── Middleware/
│       │   └── ErrorHandlingMiddleware.cs
│       ├── student/
│       │   └── dto/
│       │       ├── request/
│       │       │   └── StudentCreateRequest.cs
│       │       └── response/
│       │           └── StudentResponse.cs
│       └── Program.cs
│
└── README.md
¨