import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

interface DoctorProps {
  id: number;
  firstName: string;
  lastName: string;
  specialty: string;
  phone: string;
}

const DoctorList: React.FC = () => {
  const [doctors, setDoctors] = useState<DoctorProps[]>([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [itemsPerPage, setItemsPerPage] = useState(3);

  useEffect(() => {
    const apiUrl = `https://localhost:44303/api/Patient/pagedandsorted?pageSize=${itemsPerPage}&pageNumber=${currentPage}&orderBy=2001`;

    axios.get(apiUrl)
      .then((response) => {
        const doctorData: DoctorProps[] = response.data;
        setDoctors(doctorData);
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
      });
  }, [currentPage, itemsPerPage]);

  const paginate = (pageNumber: number) => {
    setCurrentPage(pageNumber);
  };

  const indexOfLastItem = currentPage * itemsPerPage;
  const indexOfFirstItem = indexOfLastItem - itemsPerPage;
  const currentDoctors = doctors.slice(indexOfFirstItem, indexOfLastItem);

  return (
    <div>
      <h1>Doctor List</h1>
      <Link to="/create">Add Doctor</Link>
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Specialty</th>
            <th>Phone</th>
          </tr>
        </thead>
        <tbody>
          {currentDoctors.map((doctor) => (
            <tr key={doctor.id}>
              <td>{doctor.id}</td>
              <td>{doctor.firstName}</td>
              <td>{doctor.lastName}</td>
              <td>{doctor.specialty}</td>
              <td>{doctor.phone}</td>
            </tr>
          ))}
        </tbody>
      </table>
      <div>
        {doctors.length > itemsPerPage && (
          <ul className="pagination">
            {Array(Math.ceil(doctors.length / itemsPerPage))
              .fill(null)
              .map((_, i) => (
                <li
                  key={i}
                  className={`page-item ${i + 1 === currentPage ? 'active' : ''}`}
                >
                  <button
                    className="page-link"
                    onClick={() => paginate(i + 1)}
                  >
                    {i + 1}y
                  </button>
                </li>
              ))}
          </ul>
        )}
      </div>
    </div>
  );
};

export default DoctorList;
