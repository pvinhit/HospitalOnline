import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

interface DoctorCreateProps {
  onCreate: () => void;
}

const DoctorCreate = ({ onCreate }: DoctorCreateProps) => {
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    specialty: '',
    phone: '',
  });

  const navigate = useNavigate();

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    // Không gọi axios ở đây, sẽ thực hiện trong useEffect
  };

  useEffect(() => {
    const sendDataToServer = async () => {
      try {
        const response = await axios.post(
          'https://localhost:44303/api/Doctor', formData
        );

        // Handle success, maybe redirect or show a success message
        console.log('Doctor created:', response.data);

        // Trigger the callback to update the DoctorList
        onCreate();

        // Redirect to the DoctorList page
        navigate('/');
      } catch (error) {
        console.error('Error creating doctor:', error);
      }
    };

    if (formData.firstName && formData.lastName && formData.specialty && formData.phone) {
      sendDataToServer();
    }
  }, [formData, navigate, onCreate]);

  return (
    <div>
      <h1>Create New Doctor</h1>
      <form onSubmit={handleSubmit}>
        <div>
          <label>First Name:</label>
          <input
            type="text"
            name="firstName"
            value={formData.firstName}
            onChange={handleChange}
          />
        </div>
        <div>
          <label>Last Name:</label>
          <input
            type="text"
            name="lastName"
            value={formData.lastName}
            onChange={handleChange}
          />
        </div>
        <div>
          <label>Specialty:</label>
          <input
            type="text"
            name="specialty"
            value={formData.specialty}
            onChange={handleChange}
          />
        </div>
        <div>
          <label>Phone:</label>
          <input
            type="text"
            name="phone"
            value={formData.phone}
            onChange={handleChange}
          />
        </div>
        <button type="submit">Create</button>
      </form>
    </div>
  );
};

export default DoctorCreate;
