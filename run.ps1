# Quick Build and Run script for CaraCara Project

Write-Host "🚀 Starting Build Process..." -ForegroundColor Cyan
dotnet build

if ($LASTEXITCODE -eq 0) {
    Write-Host "✅ Build Succeeded! Launching API..." -ForegroundColor Green
    dotnet run --project CaraCara.API
} else {
    Write-Host "❌ Build Failed. Please check the errors above." -ForegroundColor Red
}
