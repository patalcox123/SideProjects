using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyDao propertyDao;
        private readonly IImageDao imageDao;

        public PropertyController(IPropertyDao _propertyDao, IImageDao _imageDao)
        {
            propertyDao = _propertyDao;
            imageDao = _imageDao;
        }

        [HttpGet]
        public ActionResult<List<Property>> GetProperties()
        {
            List<Property> properties = propertyDao.GetProperties();

            if (properties.Count != 0)
            {
                return Ok(properties);
            }
            else
            {
                return BadRequest(new { message = "No properties found" });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Property> GetProperty(int id)
        {
            Property property = propertyDao.GetProperty(id);
            property.Images = imageDao.GetImages(id);

            if (property != null)
            {
                return Ok(property);
            }
            else
            {
                return BadRequest(new { message = "No property associated with that id." });
            }
        }

        [HttpPost]
        public ActionResult<int> AddProperty(Property property)
        {
            int propertyId = propertyDao.AddProperty(property);

            foreach (Image image in property.Images)
            {
                image.PropertyId = propertyId;
                imageDao.AddImage(image);
            }

            if (propertyId != 0)
            {
                return Ok(propertyId);
            }
            else
            {
                return BadRequest(new { message = "Property not successfully created." });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProperty(Property property, int id)
        {
            //TODO: Possibly merge with image update and delete. Call getImages, check against property list,
            // delete missing (or different ones), the call addImage to add the ones that are there.

            int successStatus = 0;

            if (property.PropertyId == id)
            {
                successStatus = propertyDao.UpdateProperty(property);
            }
            if (successStatus == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Property not successfully updated." });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProperty(int id)
        {
            int successStatus = 0;

            List<Image> images = imageDao.GetImages(id);
            foreach (Image image in images)
            {
                imageDao.DeleteImage(image.ImageId);
            }

            successStatus = propertyDao.DeleteProperty(id);

            if (successStatus != 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Property not successfully deleted." });
            }
        }
        [HttpGet("{id}/images")]
        public ActionResult<List<Image>> GetImages(int id)
        {
            List<Image> images = imageDao.GetImages(id);
            

            if (images.Count != 0)
            {
                return Ok(images);
            }
            else
            {
                return BadRequest(new { message = "No images found." });
            }
        }
        [HttpPut("{id}/images/{imageId}")]
        public IActionResult UpdateImage(int id, int imageId, Image image)
        {
            int successStatus = 0;

            successStatus = imageDao.UpdateThumbnail(id, imageId);

            if (successStatus != 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Image not successfully updated." });
            }
        }
        [HttpPost("{id}/images")]
        public IActionResult AddImage(Image image)
        {
            
            
            int propertyId = imageDao.AddImage(image);

            

            if (propertyId != 0)
            {
                return Ok(propertyId);
            }
            else
            {
                return BadRequest(new { message = "Image not successfully created." });
            }
        }
        [HttpDelete("{id}/images/{imageId}")]
        public IActionResult DeleteImage(int imageId)
        {
            int successStatus = 0;

            successStatus = imageDao.DeleteImage(imageId);

            if (successStatus == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Image not successfully deleted." });
            }
        }
        [HttpGet("renter/{renterId}")]
        public ActionResult<Property> GetPropertyByRenterId(int renterId)
        {
            Property property = propertyDao.GetPropertyByRenterId(renterId);
            

            if (property != null)
            {
                return Ok(property);
            }
            else
            {
                return BadRequest(new { message = "No property associated with that id." });
            }
        }
    }

        
    
}
