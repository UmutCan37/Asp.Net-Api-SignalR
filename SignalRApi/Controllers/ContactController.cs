﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _mapper.Map<List<ResultContactDto>>(_contactService.TGetAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactService.TAdd(new SignalR.EntityLayer.Entities.Contact()
            {
                FooterDescription=createContactDto.FooterDescription,
                Location=createContactDto.Location,
                Mail=createContactDto.Mail,
                Phone=createContactDto.Phone,
            });
            return Ok("iletişim Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("Kategori Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updatecontactDto)
        {
            _contactService.TUpdate(new SignalR.EntityLayer.Entities.Contact()
            {
                ContactID = updatecontactDto.ContactID,
                FooterDescription = updatecontactDto.FooterDescription,
                Location = updatecontactDto.Location,
                Mail=updatecontactDto.Mail,
                Phone=updatecontactDto.Phone,
            });
            return Ok("iletişim  güncellendi");
        }
    }
}
