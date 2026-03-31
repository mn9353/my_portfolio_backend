# API And Database Reference

## Base URL
- Local: `http://localhost:5123`

## Endpoints

### Portfolio
- `GET /api/portfolio/basic/{portfolioId}`
- `GET /api/portfolio/projects/{portfolioId}`
- `GET /api/portfolio/experiences/{portfolioId}`
- `GET /api/portfolio/education/{portfolioId}`
- `GET /api/portfolio/skills/{portfolioId}`
- `GET /api/portfolio/certifications/{portfolioId}`
- `GET /api/portfolio/achievements/{portfolioId}`
- `GET /api/portfolio/social-links/{portfolioId}`
- `GET /api/portfolio/testimonials/{portfolioId}`

### Sections
- `GET /api/sections/{portfolioId}`

## Data Storage Model

All section data is stored in PostgreSQL tables. Most tables are linked by `portfolio_id`.

### Core Profile Table
- `portfolio`
  - Primary key: `id`
  - Core profile fields such as name, role, contact, links, and theme.

### Section Tables (linked by `portfolio_id`)
- `sections`
- `projects`
- `experience`
- `education`
- `skills`
- `certifications`
- `achievements`
- `social_links`
- `testimonials`

### Other Tables
- `translations`
  - Translation values by key/language.
  - Current model does not include `portfolio_id`.

## Notes
- `projects.technologies_used`, `experience.technologies_used`, and `certifications.skills_covered` are stored as `jsonb`.
- Lists are ordered by `display_order` in repository queries where applicable.

## Secrets And Safe Git Push

### What goes to GitHub
- Commit `Portfolio.Api/appsettings.json` with placeholders only.
- Commit `Portfolio.Api/appsettings.Development.json` only if it contains no real secrets.
- Commit `Portfolio.Api/appsettings.Local.example.json` as a template only.
- Do not commit `Portfolio.Api/appsettings.Local.json` (already ignored in `.gitignore`).

### Local run (recommended: user-secrets)
From `backend/Portfolio.Api`:

```powershell
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=...;Port=5432;Database=...;Username=...;Password=...;SSL Mode=Require;Trust Server Certificate=true"
dotnet run
```

### Local run (alternative: appsettings.Local.json)
1. Copy `Portfolio.Api/appsettings.Local.example.json` to `Portfolio.Api/appsettings.Local.json`.
2. Put your real local connection string in `appsettings.Local.json`.
3. Run the API with `dotnet run`.

### Render deployment (production password)
- In Render service settings, add environment variable:
  - Key: `ConnectionStrings__DefaultConnection`
  - Value: your production PostgreSQL connection string
- Keep real production password only in Render environment variables (or Render secret files), not in git.

### Quick pre-push checklist
Run from `backend/`:

```powershell
rg -n "Password=|ConnectionStrings|DefaultConnection" Portfolio.Api/appsettings*.json
```

- Confirm no real passwords in tracked `appsettings*.json`.
- Confirm `Portfolio.Api/appsettings.Local.json` is not tracked.
