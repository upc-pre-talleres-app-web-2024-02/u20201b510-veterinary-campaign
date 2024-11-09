﻿
```
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;user=root;password=12345678;database=medicare-db-u20201b510"
  },

<!-- Dependency Injection related packages -->
<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="8.0.1" />
<!-- EntityFrameworkCore Database Persistence related packages -->
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.10"/>
<PackageReference Include="Microsoft.EntityFrameworkCore.Relational" Version="8.0.10"/>
<PackageReference Include="Microsoft.EntityFrameworkCore.Relational.Design" Version="1.1.6"/>
<!-- MySQL Database Persistence related packages -->
<PackageReference Include="MySql.EntityFrameworkCore" Version="8.0.8" />
<!-- Audit Trails related packages -->
<PackageReference Include="EntityFrameworkCore.CreatedUpdatedDate" Version="8.0.0"/>
<!-- Naming convention conversion related packages -->
<PackageReference Include="Humanizer" Version="2.14.1"/>
<!-- OpenAPI documentation related packages -->
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.9.0"/>
<PackageReference Include="Swashbuckle.AspNetCore.Annotations" Version="6.9.0"/>
```