import { useEffect, useState } from "react";
import { Button, Container, ProgressBar, Table } from "react-bootstrap";
import GrupaService from "../../services/GrupaService";
import { IoIosAdd } from "react-icons/io";
import { FaEdit, FaTrash } from "react-icons/fa";
import { Link } from "react-router-dom";
import { RoutesNames } from "../../constants";
import { useNavigate } from "react-router-dom";
import moment from "moment";

export default function Grupe() {
    const [grupe, setGrupe] = useState();
    let navigate = useNavigate();

    async function dohvatiGrupe() {
        await GrupaService.get()
            .then((res) => {
                let grupe = res.data;
                grupe.forEach(entitet => {
                    if(entitet.maksimalnopolaznika == null ) {
                        entitet.maksimalnopolaznika = 0;
                    }
                });
                setGrupe(grupe);
            })
            .catch((e) => {
                alert(e);
            });
    }

    useEffect(() => {
        dohvatiGrupe();
    }, []);

    async function obrisiGrupa(sifra) {
        const odgovor = await GrupaService.obrisi(sifra);

        if (odgovor.ok) {
            dohvatiGrupe();
        } else {
            alert(odgovor.poruka);
        }
    }

    function progressTitle(entitet) {
        return entitet.brojpolaznika + " polaznika od ukupno " + entitet.maksimalnopolaznika + " polaznika na grupi.";
    }

    function progressLabel(entitet) {
        return entitet.brojpolaznika + " / " + entitet.maksimalnopolaznika;
    }

    function progressPostotak(entitet) {
        if (entitet.maksimalnopolaznika == 0 || entitet.brojpolaznika == 0) {
            return 0;
        }

        return (entitet.brojpolaznika / entitet.maksimalnopolaznika) * 100;
    }

    return (
        <Container>
            <Link to={RoutesNames.GRUPE_NOVI} className="btn btn-success gumb">
                <IoIosAdd size={25} /> Dodaj
            </Link>
            <Table striped bordered hover responsive>
                <thead>
                    <tr>
                        <th>Naziv</th>
                        <th>Smjer</th>
                        <th>Predavač</th>
                        <th>Datum početka</th>
                        <th>Akcija</th>
                    </tr>
                </thead>
                <tbody>
                    {grupe &&
                        grupe.map((entitet, index) => (
                            <tr key={index}>
                                <td>{entitet.naziv}</td>
                                <td>{entitet.smjerNaziv}</td>
                                <td>{entitet.predavacImePrezime}</td>
                                <td>
                                    <p>
                                        {entitet.datumpocetka == null
                                            ? "nije definirano"
                                            : moment
                                                  .utc(entitet.datumpocetka)
                                                  .format(
                                                      "DD. MM. YYYY. HH:mm"
                                                  )}
                                    </p>
                                    <ProgressBar label={progressLabel(entitet)} title={progressTitle(entitet)} now={progressPostotak(entitet)} />
                                    {/* <span title="Broj upisanih polaznika">
                                        {entitet.brojpolaznika}
                                    </span>{" "}
                                    /
                                    {entitet.maksimalnopolaznika == null ? 
                                        '0'
                                     : (
                                        <span title="Maksimalno polaznika">
                                            {entitet.maksimalnopolaznika}
                                        </span>
                                    )} */}
                                </td>
                                <td className="sredina">
                                    <Button
                                        variant="primary"
                                        onClick={() => {
                                            navigate(`/grupe/${entitet.sifra}`);
                                        }}
                                    >
                                        <FaEdit size={25} />
                                    </Button>
                                    &nbsp;&nbsp;&nbsp;
                                    <Button
                                        variant="danger"
                                        onClick={() =>
                                            obrisiGrupa(entitet.sifra)
                                        }
                                    >
                                        <FaTrash size={25} />
                                    </Button>
                                </td>
                            </tr>
                        ))}
                </tbody>
            </Table>
        </Container>
    );
}
