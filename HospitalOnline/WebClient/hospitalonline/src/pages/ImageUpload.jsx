import React, { useState } from 'react';
import axios from 'axios';

function ImageUpload() {
  const [selectedFile, setSelectedFile] = useState(null);

  const handleFileChange = (event) => {
    setSelectedFile(event.target.files[0]);
  };

  const handleUpload = async () => {
    if (!selectedFile) {
      alert('Image uploaded successfully!!!!!!Please select an image to upload.');
      return;
    }

    const formData = new FormData();
    formData.append('file', selectedFile);

    try {
      // Gửi yêu cầu POST đến API endpoint
      const response = await axios.post('https://localhost:44306/api/Upload/image', formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      });

      // Xử lý phản hồi từ API nếu cần
      console.log('Response:', response.data);
      alert('Image uploaded successfully.');
    } catch (error) {
      console.error('Error:', error);
      alert('An error occurred while uploading the image.');
    }
  };

  return (
    <div>
      <h2>Upload an Image</h2>
      <input type="file" onChange={handleFileChange} accept="image/*" />
      <button onClick={handleUpload}>Upload</button>
    </div>
  );
}

export default ImageUpload;
