import 'bootstrap/dist/css/bootstrap.css';
import { useEffect, useState } from "react";


const App = () => {

    const [tareas, setTareas] = useState([])



    const mostrarTareas = async () => {

        const response = await fetch("api/tarea/Lista");

        if (response.ok) {

            const data = await response.json();
            setTareas(data);
        } else {
            consol.log("status code" + response.status);
        }
    }

    useEffect(() => {
        mostrarTareas();
    }, [])


    return (
        <div className="container bg-dark p-4 vh-100">

            <h2 className="text-white"> Lista de tareas </h2>
            <div className="row">
                <div className="col-sm-12"> </div>

            </div>

            <div className="row mt-4">
                <div className="col-sm-12">

                    <div className="list-group">

                        {
                            tareas.map(
                                (item) => (
                                    <div key={item.idTarea} className="list-group-item list-group-item-action">

                                        <h5 className="text-primary">{item.descripcion}</h5>

                                        <div className="d-flex justify-content-between">
                                            <small>{item.fechaRegistro}</small>
                                            <button className="btn btn-sm btn-outline-danger">Cerrar</button>
                                        </div>

                                    </div>

                                )
                            )
                        }

                    </div>
                </div>

            </div>





        </div>
    )
}

export default App;