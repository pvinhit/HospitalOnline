// // DoctorList.jsx
// import React, { useEffect, useState } from 'react';
// import axios from 'axios';

// const DoctorList = () => {
//   const [doctors, setDoctors] = useState([]);

//   useEffect(() => {
//     axios.get('https://localhost:44303/api/Doctor')
//       .then((response) => {
//         const doctorData = response.data;
//         setDoctors(doctorData);
//       })
//       .catch((error) => {
//         console.error('Error fetching data:', error);
//       });
//   }, []);

//   return (
//     <div>
//       <h1>Doctor List</h1>
//       <table>
//         <thead>
//           <tr>
//             <th>ID</th>
//             <th>First Name</th>
//             <th>Last Name</th>
//             <th>Specialty</th>
//             <th>Phone</th>
//           </tr>
//         </thead>
//         <tbody>
//           {doctors.map((doctor) => (
//             <tr key={doctor.id}>
//               <td>{doctor.id}</td>
//               <td>{doctor.firstName}</td>
//               <td>{doctor.lastName}</td>
//               <td>{doctor.specialty}</td>
//               <td>{doctor.phone}</td>
//             </tr>
//           ))}
//         </tbody>
//       </table>
//     </div>
//   );
// };

// export default DoctorList;
