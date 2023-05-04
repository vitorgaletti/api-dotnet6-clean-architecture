﻿using MP.Api.DotNet6.Application.DTOs;

namespace MP.Api.DotNet6.Application.Services.Interfaces {
    public interface IPersonService {
        Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
        Task<ResultService<PersonDTO>> GetByIdAsync(int id);
        Task<ResultService<ICollection<PersonDTO>>> GetAsync();

    }
}
