﻿namespace ManhPT_MidAssignment.Application.DTOs.AuthDTOs
{
    public record LoginResponse(bool Flag, string Message = null!, string Token = null!);
}
